using System;
using System.Collections.Generic;
using System.Text;

namespace LETin.Billingo.Api
{
    public class PaymentMethod
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Always)]
        public string Id { get; set; }
        [Newtonsoft.Json.JsonProperty("lang_code", Required = Newtonsoft.Json.Required.Always)]
        public string LangCode { get; set; }
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Always)]
        public string Name { get; set; }
        [Newtonsoft.Json.JsonProperty("advance_paid", Required = Newtonsoft.Json.Required.Always)]
        public string AdvancePaid { get; set; }
    }
}
