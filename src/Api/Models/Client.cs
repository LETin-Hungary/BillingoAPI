namespace LETin.Billingo.Api
{
    public partial class Client
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Always)]
        public string Name { get; set; }
        [Newtonsoft.Json.JsonProperty("force", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool Force { get; set; }
        [Newtonsoft.Json.JsonProperty("email", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Email { get; set; }
        [Newtonsoft.Json.JsonProperty("taxcode", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Taxcode { get; set; }
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Type { get; set; }
        [Newtonsoft.Json.JsonProperty("fokonyv_szam", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Fokonyv_szam { get; set; }
        [Newtonsoft.Json.JsonProperty("phone", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Phone { get; set; }
        [Newtonsoft.Json.JsonProperty("internal_id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Internal_id { get; set; }
        [Newtonsoft.Json.JsonProperty("billing_address", Required = Newtonsoft.Json.Required.Always)]
        public BillingAddress Billing_address { get; set; } = new BillingAddress();
        [Newtonsoft.Json.JsonProperty("bank", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Bank Bank { get; set; } = new Bank();
        [Newtonsoft.Json.JsonProperty("defaults", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Defaults Defaults { get; set; } = new Defaults();

    }
    public partial class BillingAddress
    {
        [Newtonsoft.Json.JsonProperty("street_name", Required = Newtonsoft.Json.Required.Always)]
        public string Street_name { get; set; }
        [Newtonsoft.Json.JsonProperty("street_type", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Street_type { get; set; }
        [Newtonsoft.Json.JsonProperty("house_nr", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string House_nr { get; set; }
        [Newtonsoft.Json.JsonProperty("block", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Block { get; set; }
        [Newtonsoft.Json.JsonProperty("entrance", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Entrance { get; set; }
        [Newtonsoft.Json.JsonProperty("floor", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Floor { get; set; }
        [Newtonsoft.Json.JsonProperty("door", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Door { get; set; }
        [Newtonsoft.Json.JsonProperty("city", Required = Newtonsoft.Json.Required.Always)]
        public string City { get; set; }
        [Newtonsoft.Json.JsonProperty("postcode", Required = Newtonsoft.Json.Required.Always)]
        public string Postcode { get; set; }
        [Newtonsoft.Json.JsonProperty("country", Required = Newtonsoft.Json.Required.Always)]
        public string Country { get; set; }
        [Newtonsoft.Json.JsonProperty("district", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string District { get; set; }

    }
    public partial class Bank
    {
        [Newtonsoft.Json.JsonProperty("iban", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Iban { get; set; }
        [Newtonsoft.Json.JsonProperty("swift", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Swift { get; set; }
        [Newtonsoft.Json.JsonProperty("account_no", Required = Newtonsoft.Json.Required.Always)]
        public string Account_no { get; set; }

    }
    public partial class Defaults
    {
        [Newtonsoft.Json.JsonProperty("payment_method", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Payment_method { get; set; }
        [Newtonsoft.Json.JsonProperty("electronic_invoice", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Electronic_invoice { get; set; }
        [Newtonsoft.Json.JsonProperty("invoice_due_days", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Invoice_due_days { get; set; }
        [Newtonsoft.Json.JsonProperty("invoice_currency", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Invoice_currency { get; set; }
        [Newtonsoft.Json.JsonProperty("invoice_template_lang_code", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Invoice_template_lang_code { get; set; }
    }
}