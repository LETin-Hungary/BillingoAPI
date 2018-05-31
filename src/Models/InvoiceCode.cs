using Newtonsoft.Json;

namespace LETin.BillingoAPI.Models
{
    public class InvoiceCode
    {
        [JsonProperty("code")]
        public string Code { get; set; }
    }
}