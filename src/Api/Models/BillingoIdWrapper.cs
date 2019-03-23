namespace LETin.Billingo.Api
{
    public class BillingoIdWrapper<T>
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Always)]
        public int Id { get; set; }
        [Newtonsoft.Json.JsonProperty("attributes", Required = Newtonsoft.Json.Required.Always)]
        public T Attributes { get; set; }
    }
}
