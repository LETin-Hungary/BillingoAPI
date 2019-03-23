using LETin.Billingo.Api;
using System;
using System.Threading.Tasks;

namespace LETin.Billingo.AspNetCore
{
    public class InvoiceService
    {
        private readonly ClientsRepository clients;
        private readonly InvoicesRepository invoices;

        public InvoiceService(ClientsRepository clients, InvoicesRepository invoices)
        {
            this.clients = clients;
            this.invoices = invoices;
        }

        public async Task<InvoiceWithClient> GenerateInvoiceForNewClientAsync(Invoice invoice, Client client)
        {
            var clientWithId = await clients.CreateAsync(client);
            invoice.Client_uid = clientWithId.Id;
            var invoiceWithId = await invoices.CreateAsync(invoice);
            return new InvoiceWithClient
            {
                Client = clientWithId,
                Invoice = invoiceWithId,
            };
        }

        public async Task<InvoiceWithClient> GenerateInvoiceForClientAsync(Invoice invoice, int clientId)
        {
            invoice.Client_uid = clientId;
            var invoiceWithId = await invoices.CreateAsync(invoice);
            return new InvoiceWithClient
            {
                Invoice = invoiceWithId,
            };
        }
    }
}
