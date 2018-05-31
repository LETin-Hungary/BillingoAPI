using Newtonsoft.Json;

namespace LETin.BillingoAPI.Models
{
    public class InvoiceBlock
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("attributes")]
        public InvoiceBlockAttribute Attributes { get; set; }
    }

    public class InvoiceBlockAttribute
    {
        [JsonProperty("uid")]
        public int Uid { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("prefix")]
        public string Prefix { get; set; }
    }
}