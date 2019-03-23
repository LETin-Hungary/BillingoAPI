using System.Collections.Generic;
using Newtonsoft.Json;

namespace LETin.Billingo.Api
{
    public class BillingoError
    {
        [JsonProperty("error")]
        public string Error { get; set; }
        [JsonProperty("errors")]
        public List<string> Errors { get; set; }
        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}