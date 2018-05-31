using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace LETin.BillingoAPI.Models
{
    public class Invoice
    {
        /// <summary>
        /// The bank account ID
        /// </summary>
        [JsonProperty("bank_account_uid", NullValueHandling = NullValueHandling.Ignore)]
        public int BankAccountUid { get; set; }

        /// <summary>
        /// The invoice block ID, should be left out if using default block
        /// </summary>
        [JsonProperty("block_uid")]
        public int BlockUid { get; set; }

        /// <summary>
        /// The client ID
        /// </summary>
        [JsonProperty("client_uid")]
        public int ClientUid { get; set; }

        /// <summary>
        /// The comment that should be visible on the invoice
        /// </summary>
        [JsonProperty("comment")]
        public string Comment { get; set; }

        /// <summary>
        /// ISO 4217 currency code
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// The date when the invoice is due
        /// </summary>
        [JsonProperty("due_date")]
        public string DueDate { get; set; }

        /// <summary>
        /// 1 if invoice needs digital signature and trusted timestamp
        /// </summary>
        [JsonProperty("electronic_invoice")]
        public int ElectronicInvoice { get; set; }

        /// <summary>
        /// Exchange rate for the invoice
        /// </summary>
        [JsonProperty("exchange_rate", NullValueHandling = NullValueHandling.Ignore)]
        public double? ExchangeRate { get; set; }

        /// <summary>
        /// The date the invoice was fulfilled
        /// </summary>
        [JsonProperty("fulfillment_date")]
        public DateTime FulfillmentDate { get; set; }

        [JsonProperty("is_paid", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsPaid { get; set; }

        /// <summary>
        /// List of the items
        /// </summary>
        [JsonProperty("items")]
        public ICollection<InvoiceItem> Items { get; set; } // TODO: InvoiceItem or InvoiceProductItem

        /// <summary>
        /// The payment method ID
        /// </summary>
        [JsonProperty("payment_method")]
        public int PaymentMethod { get; set; }

        /// <summary>
        /// Invoice rounding
        /// </summary>
        [JsonProperty("round_to", NullValueHandling = NullValueHandling.Ignore)]
        public double? RoundTo { get; set; }

        /// <summary>
        /// The language code
        /// </summary>
        [JsonProperty("template_lang_code")]
        public string TemplateLangCode { get; set; }

        /// <summary>
        /// Invoice type
        /// </summary>
        [JsonProperty("type")]
        public int Type { get; set; }
    }
}