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
using System.Net.Http.Headers;

namespace LETin.Billingo.Api
{
    public class BillingoWebAPI : IDisposable
    {
        private readonly string privateKey;
        private readonly string publicKey;
        private readonly double expireSeconds;
        private readonly IDateTimeProvider provider;
        private readonly string issuerURI;
        private AuthenticationHeaderValue authenticationHeaderCache;
        HttpClient client = new HttpClient();

        public string WebAPIUrl { get; set; } = "https://www.billingo.hu/api";
        public BillingoWebAPI(string issuerURI, string publicKey, string privateKey, double tokenExpireSeconds, IDateTimeProvider provider = null)
        {
            this.privateKey = privateKey;
            this.publicKey = publicKey;
            this.expireSeconds = tokenExpireSeconds;
            this.provider = provider ?? new DefaultDateTimeProvider();
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

        private AuthenticationHeaderValue GenerateToken()
        {
            if (authenticationHeaderCache != null)
            {
                return authenticationHeaderCache;
            }
            var expires = provider.CurrentTime.AddSeconds(expireSeconds);
            var timeStamp = ((int)(provider.CurrentTime.Subtract(new DateTime(1970, 1, 1))).TotalSeconds).ToString();

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

            return authenticationHeaderCache = new AuthenticationHeaderValue("Bearer", new JwtSecurityTokenHandler().WriteToken(token));
        }

        public async Task<HttpResponseMessage> GetRawAsync(string url)
        {
            client.DefaultRequestHeaders.Authorization = GenerateToken();
            return await client.GetAsync($"{WebAPIUrl}{url}");
        }

        public async Task GetJsonAsync(string url)
        {
            await DecodeObject<object>(await GetRawAsync(url));
        }

        public async Task<T> GetJsonAsync<T>(string url)
        {
            return await DecodeObject<T>(await GetRawAsync(url));
        }

        private async Task<HttpResponseMessage> PostRawAsync(string url, object model)
        {
            client.DefaultRequestHeaders.Authorization = GenerateToken();
            var json = JsonConvert.SerializeObject(model, Formatting.None);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            content.Headers.ContentLength = Encoding.UTF8.GetByteCount(json);
            return await client.PostAsync($"{WebAPIUrl}{url}", content);
        }

        public async Task<T> PostJsonAsync<T>(string url, object model)
        {
            return await DecodeObject<T>(await PostRawAsync(url, model));
        }

        private async Task<HttpResponseMessage> PutRawAsync(string url, object model)
        {
            client.DefaultRequestHeaders.Authorization = GenerateToken();
            return await client.PutAsJsonAsync($"{WebAPIUrl}{url}", model);
        }

        public async Task<T> PutJsonAsync<T>(string url, object model)
        {
            return await DecodeObject<T>(await PutRawAsync(url, model));
        }

        private async Task<HttpResponseMessage> DeleteRawAsync(string url)
        {
            client.DefaultRequestHeaders.Authorization = GenerateToken();
            return await client.DeleteAsync($"{WebAPIUrl}{url}");
        }

        public async Task<T> DeleteJsonAsync<T>(string url)
        {
            return await DecodeObject<T>(await DeleteRawAsync(url));
        }

        private async Task<T> DecodeObject<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var obj = await response.Content.ReadAsAsync<BillingoResponse<T>>();
                if (obj.Success)
                {
                    return obj.Data;
                }
                throw new BillingoAPIException();
            }
            else
            {
                try
                {
                    var obj = await response.Content.ReadAsAsync<BillingoError>();
                    if (obj.Error != null)
                    {
                        throw new BillingoAPIException(obj.Error);
                    }
                    if (obj.Errors != null)
                    {
                        throw new BillingoAPIException(obj.Errors);
                    }
                    throw new BillingoAPIException("Unexpected Error");
                }
                catch (BillingoAPIException)
                {
                    throw;
                }
                catch (JsonSerializationException e)
                {
                    throw new BillingoAPIException($"Unable to parse answer. ({await response.Content.ReadAsStringAsync()}) See inner exception.", e);
                }
            }
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
