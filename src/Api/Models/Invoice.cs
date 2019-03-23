namespace LETin.Billingo.Api
{
    public partial class Invoice
    {
        /// <summary>The date the invoice was fulfilled</summary>
        [Newtonsoft.Json.JsonProperty("fulfillment_date", Required = Newtonsoft.Json.Required.Always)]
        public string Fulfillment_date { get; set; }
        /// <summary>The date when the invoice is due</summary>
        [Newtonsoft.Json.JsonProperty("due_date", Required = Newtonsoft.Json.Required.Always)]
        public string Due_date { get; set; }
        /// <summary>The payment method ID</summary>
        [Newtonsoft.Json.JsonProperty("payment_method", Required = Newtonsoft.Json.Required.Always)]
        public int Payment_method { get; set; }
        [Newtonsoft.Json.JsonProperty("is_paid", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool Is_paid { get; set; }
        /// <summary>The bank account ID</summary>
        [Newtonsoft.Json.JsonProperty("bank_account_uid", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Bank_account_uid { get; set; }
        /// <summary>Invoice rounding</summary>
        [Newtonsoft.Json.JsonProperty("round_to", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public InvoiceRound_to Round_to { get; set; }
        /// <summary>The comment that should be visible on the invoice</summary>
        [Newtonsoft.Json.JsonProperty("comment", Required = Newtonsoft.Json.Required.Always)]
        public string Comment { get; set; }
        /// <summary>ISO 4217 currency code</summary>
        [Newtonsoft.Json.JsonProperty("currency", Required = Newtonsoft.Json.Required.Always)]
        public string Currency { get; set; }
        /// <summary>The client ID</summary>
        [Newtonsoft.Json.JsonProperty("client_uid", Required = Newtonsoft.Json.Required.Always)]
        public int Client_uid { get; set; }
        /// <summary>The invoice block ID, should be left out if using default block</summary>
        [Newtonsoft.Json.JsonProperty("block_uid", Required = Newtonsoft.Json.Required.Always)]
        public int Block_uid { get; set; }
        /// <summary>1 if invoice needs digital signature and trusted timestamp</summary>
        [Newtonsoft.Json.JsonProperty("electronic_invoice", Required = Newtonsoft.Json.Required.Always)]
        public InvoiceElectronic_invoice Electronic_invoice { get; set; }
        /// <summary>The language code</summary>
        [Newtonsoft.Json.JsonProperty("template_lang_code", Required = Newtonsoft.Json.Required.Always)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public InvoiceTemplate_lang_code Template_lang_code { get; set; }
        /// <summary>Invoice type</summary>
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Always)]
        public InvoiceType Type { get; set; }
        /// <summary>Exchange rate for the invoice</summary>
        [Newtonsoft.Json.JsonProperty("exchange_rate", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public decimal Exchange_rate { get; set; }
        /// <summary>List of the items</summary>
        [Newtonsoft.Json.JsonProperty("items", Required = Newtonsoft.Json.Required.Always)]
        public System.Collections.Generic.List<InvoiceItemBase> Items { get; set; } = new System.Collections.Generic.List<InvoiceItemBase>();

    }
    public enum InvoiceRound_to
    {
        _0 = 0,
        _1 = 1,
        _5 = 5,
        _10 = 10,
    }
    public enum InvoiceElectronic_invoice
    {
        _0 = 0,
        _1 = 1,
    }
    public enum InvoiceTemplate_lang_code
    {
        [System.Runtime.Serialization.EnumMember(Value = @"hu")]
        hu = 0,
        [System.Runtime.Serialization.EnumMember(Value = @"en")]
        en = 1,
        [System.Runtime.Serialization.EnumMember(Value = @"de")]
        de = 2,
        [System.Runtime.Serialization.EnumMember(Value = @"fr")]
        fr = 3,
        [System.Runtime.Serialization.EnumMember(Value = @"it")]
        it = 4,
        [System.Runtime.Serialization.EnumMember(Value = @"sk")]
        sk = 5,
        [System.Runtime.Serialization.EnumMember(Value = @"hr")]
        hr = 6,
        [System.Runtime.Serialization.EnumMember(Value = @"ro")]
        ro = 7,
    }
    public enum InvoiceType
    {
        /// <summary>
        /// Draft
        /// </summary>
        _0 = 0,
        /// <summary>
        /// Proforma invoice
        /// </summary>
        _1 = 1,
        /// <summary>
        /// Not used, reserved
        /// </summary>
        _2 = 2,
        /// <summary>
        /// Normal invoice
        /// </summary>
        _3 = 3,
    }
}