using System;
using System.Collections.Generic;
using System.Text;

namespace LETin.Billingo.Api
{
    public class InvoiceBuilder
    {
        private Invoice invoice;

        public InvoiceBuilder()
        {
            invoice = new Invoice();
        }
        public InvoiceBuilder SetDefaults(int paymentMethodId, int clientId, int blockId, List<InvoiceItemBase> invoiceItems)
        {
            return SetFulfillmentDate(DateTime.Now)
                .SetDueDate(DateTime.Now)
                .SetPaymentMethodId(paymentMethodId)
                .SetIsPaid(false)
                .SetComment("")
                .SetRoundTo(InvoiceRound_to._0)
                .SetTemplateLangCode(InvoiceTemplate_lang_code.hu)
                .SetElectronicInvoice(true)
                .SetCurrecncy("HUF")
                .SetExchangeRate(1)
                .SetClientId(clientId)
                .SetBlockId(blockId)
                .SetItems(invoiceItems)
                .SetInvoiceType(InvoiceType._3);
        }

        public InvoiceBuilder SetItems(List<InvoiceItemBase> invoiceItems)
        {
            invoice.Items = invoiceItems;
            return this;
        }

        public InvoiceBuilder SetBlockId(int blockId)
        {
            invoice.Block_uid = blockId;
            return this;
        }

        public InvoiceBuilder SetClientId(int clientId)
        {
            invoice.Client_uid = clientId;
            return this;
        }

        public InvoiceBuilder SetFulfillmentDate(DateTime dateTime)
        {
            invoice.Fulfillment_date = dateTime.ToString("yyyy-MM-dd");
            return this;
        }
        public InvoiceBuilder SetDueDate(DateTime dateTime)
        {
            invoice.Due_date = dateTime.ToString("yyyy-MM-dd");
            return this;
        }
        public InvoiceBuilder SetPaymentMethodId(int paymentMethodId)
        {
            invoice.Payment_method = paymentMethodId;
            return this;
        }
        public InvoiceBuilder SetIsPaid(bool paid)
        {
            invoice.Is_paid = paid;
            return this;
        }
        public InvoiceBuilder SetComment(string comment)
        {
            invoice.Comment = comment;
            return this;
        }
        public InvoiceBuilder SetRoundTo(InvoiceRound_to roundTo)
        {
            invoice.Round_to = roundTo;
            return this;
        }
        public InvoiceBuilder SetTemplateLangCode(InvoiceTemplate_lang_code code)
        {
            invoice.Template_lang_code = code;
            return this;
        }
        public InvoiceBuilder SetElectronicInvoice(bool isElectronic)
        {
            invoice.Electronic_invoice = isElectronic ? InvoiceElectronic_invoice._1 : InvoiceElectronic_invoice._0;
            return this;
        }
        public InvoiceBuilder SetCurrecncy(string currency)
        {
            invoice.Currency = currency;
            return this;
        }
        public InvoiceBuilder SetExchangeRate(decimal exchangeRate)
        {
            invoice.Exchange_rate = exchangeRate;
            return this;
        }
        public InvoiceBuilder SetInvoiceType(InvoiceType type)
        {
            invoice.Type = type;
            return this;
        }
        public Invoice Build()
        {
            return invoice;
        }
    }
}
