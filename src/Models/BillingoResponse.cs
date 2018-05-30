using System.Collections.Generic;
using Newtonsoft.Json;

namespace LETin.BillingoAPI.Models
{
    public class BillingoResponse<T>
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("data")]
        public ICollection<T> Data { get; set; }
        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}