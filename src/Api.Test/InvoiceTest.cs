using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace LETin.Billingo.Api.Test
{
    public class InvoiceTest : TestBase
    {
        private readonly IInvoicesRepository invoicesRepository;

        public InvoiceTest() : base()
        {
            invoicesRepository = new InvoicesRepository(billingoApi);
        }
        [Fact]
        public async Task CreateAsync()
        {
            var clientId = await GetClientIdAsync();
            var items = new List<InvoiceItemBase>
            {
                new InvoiceItem
                {
                    Description = "Teszt termék (Próba)",
                    Gross_unit_price = 1000,
                    Qty = 2,
                    Unit = "db",
                    Vat_id = 1,
                },
            };
            var invoice = new InvoiceBuilder().SetDefaults(1, clientId, 0, items).SetElectronicInvoice(false).Build();
            var createdInvoice = await invoicesRepository.CreateAsync(invoice);
            Assert.False(invoice.Is_paid);
        }
        [Fact]
        public async Task GetInvoicesAsync()
        {
            var invoices = await invoicesRepository.GetListAsync();
            Assert.True(invoices.Count < 21);
        }

        private async Task<int> GetClientIdAsync()
        {
            var clientRepository = new ClientsRepository(billingoApi);
            var clients = await clientRepository.GetListAsync(1, 1);
            return clients?.SingleOrDefault()?.Id ?? (await clientRepository.CreateAsync(new Client
            {
                Name = "Test Elek",
                Email = "test@test.hu",
                Billing_address = new BillingAddress
                {
                    Country = "Magyarország",
                    Postcode = "1117",
                    City = "Budapest",
                    Street_name = "Test",
                    Street_type = "utca",
                    House_nr = "10",
                },
                Bank = new Bank
                {
                    Account_no = "11739009-23905470-"
                },
                Defaults = new Defaults
                {
                    Electronic_invoice = "true",
                    Invoice_currency = "HUF"
                }
            })).Id;
        }
    }
}
