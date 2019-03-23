using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace LETin.Billingo.Api.Test
{
    public class ClientsTest : TestBase
    {
        private readonly IClientsRepository clientsRepository;

        public ClientsTest() : base()
        {
            clientsRepository = new ClientsRepository(billingoApi);
        }
        [Fact]
        public async Task CreateAsync()
        {
            var client = await clientsRepository.CreateAsync(new Client
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
                Force = true,
                Defaults = new Defaults
                {
                    Electronic_invoice = "true",
                    Invoice_currency = "HUF"
                }
            });
        }
        [Fact]
        public async Task CreateWithoutDefaultsAsync()
        {
            var client = await clientsRepository.CreateAsync(new Client
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
                Force = true,
                Bank = new Bank
                {
                    Account_no = "11739009-23905470-"
                }
            });
        }
        [Fact]
        public async Task GetListAsync()
        {
            var clients = await clientsRepository.GetListAsync(1, 1);
        }
        [Fact]
        public async Task GetOneAsync()
        {
            var client = await clientsRepository.GetAsync(await GetClientIdAsync());
        }
        [Fact]
        public async Task GetInvoicesAsync()
        {
            var invoices = await clientsRepository.GetListAsync();
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
