using Newtonsoft.Json;

namespace LETin.Billingo.Api
{
    public class InvoiceBlock
    {
        [JsonProperty("uid")]
        public int Uid { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("prefix")]
        public string Prefix { get; set; }
    }
}