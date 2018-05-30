using System.Collections.Generic;
using Newtonsoft.Json;

namespace LETin.BillingoAPI.Models
{
    public class BillingoError
    {
        [JsonProperty("error")]
        public string Error { get; set; }
        [JsonProperty("errors")]
        public ICollection<string> Errors { get; set; }
        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}