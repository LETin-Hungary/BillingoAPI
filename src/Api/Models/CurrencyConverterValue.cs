namespace LETin.Billingo.Api
{
    public class CurrencyConverterValue
    {
        [Newtonsoft.Json.JsonProperty("value", Required = Newtonsoft.Json.Required.Always)]
        public double Value { get; set; }
    }
}