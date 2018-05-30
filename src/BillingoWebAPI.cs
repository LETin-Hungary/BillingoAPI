using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using LETin.BillingoAPI.Models;

namespace LETin.BillingoAPI
{
    public class BillingoWebAPI
    {
        private readonly string privateKey;
        private readonly string publicKey;
        private readonly double expireSeconds;
        private readonly string issuerURI;

        public string WebAPIUrl { get; set; } = "https://www.billingo.hu/api";
        public BillingoWebAPI(string issuerURI, string publicKey, string privateKey, double tokenExpireSeconds)
        {
            this.privateKey = privateKey;
            this.publicKey = publicKey;
            this.expireSeconds = tokenExpireSeconds;
            this.issuerURI = issuerURI;
        }

        private string MD5Encode(string input)
        {
            using (var md5 = MD5.Create())
            {
                var hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        private string tokenCache;

        private string GenerateToken()
        {
            if (tokenCache != null)
            {
                return tokenCache;
            }
            var expires = DateTime.Now.AddSeconds(expireSeconds);
            var timeStamp = DateTime.Now.Ticks.ToString();

            var claims = new List<Claim>
            {
                new Claim("alg", "HS256"),
                new Claim("typ", "JWT"),
                new Claim("sub", publicKey),
                new Claim("iat", timeStamp),
                new Claim("iss", issuerURI),
                new Claim("jti", MD5Encode(publicKey + timeStamp)),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(privateKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuerURI,
                issuerURI,
                claims,
                expires: expires,
                signingCredentials: creds
            );

            tokenCache = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenCache;
        }

        private async Task<HttpResponseMessage> RequestRawAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", GenerateToken());
                using (HttpResponseMessage response = await client.GetAsync($"{WebAPIUrl}{url}"))
                {
                    return response;
                }
            }
        }

        protected async Task<ICollection<T>> RequestJsonAsync<T>(string url)
        {
            var response = await RequestRawAsync(url);
            var data = await response.Content.ReadAsByteArrayAsync();
            var text = Encoding.UTF8.GetString(data);
            if (response.StatusCode != HttpStatusCode.OK || response.StatusCode != HttpStatusCode.Created)
            {
                var obj = JsonConvert.DeserializeObject<BillingoResponse<T>>(text);
                if (obj.Success)
                {
                    return obj.Data;
                }
                throw new BillingoAPIException();
            }
            else
            {
                var obj = JsonConvert.DeserializeObject<BillingoError>(text);
                throw new BillingoAPIException(obj.Error);
            }
        }
    }
}
