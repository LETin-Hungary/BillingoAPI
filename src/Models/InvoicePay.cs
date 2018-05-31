using System;
using Newtonsoft.Json;

namespace LETin.BillingoAPI.Models
{
    public class InvoicePay
    {
        /// <summary>
        /// The gross amount paid
        /// </summary>
        [JsonProperty("amount")]
        public double Amount { get; set; }

        /// <summary>
        /// The date when the payment was made
        /// </summary>
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// The payment method ID
        /// </summary>
        [JsonProperty("payment_method")]
        public int PaymentMethod { get; set; }
    }
}