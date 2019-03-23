using Newtonsoft.Json;

namespace LETin.Billingo.Api
{
    public class BillingoResponse<T>
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("data")]
        public T Data { get; set; }
        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}