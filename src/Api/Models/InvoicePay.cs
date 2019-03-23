namespace LETin.Billingo.Api
{
    public partial class InvoicePay
    {
        /// <summary>The gross amount paid</summary>
        [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.Always)]
        public double Amount { get; set; }
        /// <summary>The date when the payment was made</summary>
        [Newtonsoft.Json.JsonProperty("date", Required = Newtonsoft.Json.Required.Always)]
        public string Date { get; set; }
        /// <summary>The payment method ID</summary>
        [Newtonsoft.Json.JsonProperty("payment_method", Required = Newtonsoft.Json.Required.Always)]
        public int Payment_method { get; set; }
    }
}