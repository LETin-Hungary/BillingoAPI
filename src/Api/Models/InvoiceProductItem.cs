namespace LETin.Billingo.Api
{
    public partial class InvoiceProductItem : InvoiceItemBase
    {
        [Newtonsoft.Json.JsonProperty("product_uid", Required = Newtonsoft.Json.Required.Always)]
        public int Product_uid { get; set; }
    }
}