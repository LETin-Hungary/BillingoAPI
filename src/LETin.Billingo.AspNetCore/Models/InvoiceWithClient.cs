using LETin.Billingo.Api;

namespace LETin.Billingo.AspNetCore
{
    public class InvoiceWithClient
    {
        public BillingoIdWrapper<Invoice> Invoice { get; internal set; }
        public BillingoIdWrapper<Client> Client { get; internal set; }
    }
}