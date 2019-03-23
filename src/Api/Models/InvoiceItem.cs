namespace LETin.Billingo.Api
{
    public partial class InvoiceItem : InvoiceItemBase
    {
        [Newtonsoft.Json.JsonProperty("description", Required = Newtonsoft.Json.Required.Always)]
        public string Description { get; set; }
        [Newtonsoft.Json.JsonProperty("net_unit_price", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double Net_unit_price { get; set; }
        [Newtonsoft.Json.JsonProperty("gross_unit_price", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double Gross_unit_price { get; set; }
        [Newtonsoft.Json.JsonProperty("qty", Required = Newtonsoft.Json.Required.Always)]
        public double Qty { get; set; }
        [Newtonsoft.Json.JsonProperty("unit", Required = Newtonsoft.Json.Required.Always)]
        public string Unit { get; set; }
        /// <summary>The VAT ID for the item</summary>
        [Newtonsoft.Json.JsonProperty("vat_id", Required = Newtonsoft.Json.Required.Always)]
        public int Vat_id { get; set; }
        [Newtonsoft.Json.JsonProperty("item_comment", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Item_comment { get; set; }

    }
}