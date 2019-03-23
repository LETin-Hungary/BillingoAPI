using System.Collections.Generic;
using System.Threading.Tasks;

namespace LETin.Billingo.Api
{
    public class BlocksRepository : IBlocksRepository
    {
        private readonly BillingoWebAPI api;

        public BlocksRepository(BillingoWebAPI api)
        {
            this.api = api;
        }
        public async Task<ICollection<BillingoIdWrapper<InvoiceBlock>>> GetAvailableInvoiceBlocksAsync()
        {
            return await api.GetJsonAsync<ICollection<BillingoIdWrapper<InvoiceBlock>>>($"/invoices/blocks");
        }
    }
}
