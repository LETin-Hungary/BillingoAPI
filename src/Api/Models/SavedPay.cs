using Newtonsoft.Json;

namespace LETin.BillingoAPI.Models
{
    public class SavedPay
    {
        [JsonProperty("outstanding")]
        public int Outstanding { get; set; }
        [JsonProperty("fully_paid")]
        public bool FullyPaid { get; set; }
    }
}