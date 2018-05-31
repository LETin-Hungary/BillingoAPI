using System;
using Newtonsoft.Json;

namespace LETin.BillingoAPI.Models
{
    public class SavedInvoice
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("attributes")]
        public SavedInvoiceAttritubes Attributes { get; set; }
    }

    public class SavedInvoiceAttritubes
    {
        /// <summary>
        /// The date the invoice was fulfilled
        /// </summary>
        [JsonProperty("fulfillment_date")]
        public DateTime FulfillmentDate { get; set; }
        /// <summary>
        /// The date when the invoice is due
        /// </summary>
        [JsonProperty("due_date")]
        public string DueDate { get; set; }
        [JsonProperty("total")]
        public double Total { get; set; }
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
        [JsonProperty("invoice_no")]
        public string InvoiceNo { get; set; }
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
        [JsonProperty("uid")]
        public int Uid { get; set; }
    }
}