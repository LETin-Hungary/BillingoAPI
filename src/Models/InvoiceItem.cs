using Newtonsoft.Json;

namespace LETin.BillingoAPI.Models
{
    public class InvoiceItem
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("gross_unit_price", NullValueHandling = NullValueHandling.Ignore)]
        public double? GrossUnitPrice { get; set; }

        [JsonProperty("item_comment", NullValueHandling = NullValueHandling.Ignore)]
        public string ItemComment { get; set; }

        [JsonProperty("net_unit_price", NullValueHandling = NullValueHandling.Ignore)]
        public double? NetUnitPrice { get; set; }

        [JsonProperty("qty")]
        public double Qty { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }

        /// <summary>
        /// The VAT ID for the item
        /// </summary>
        [JsonProperty("vat_id")]
        public double VatId { get; set; }
    }
}