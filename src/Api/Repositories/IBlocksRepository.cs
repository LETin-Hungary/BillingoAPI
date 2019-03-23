using System.Collections.Generic;
using System.Threading.Tasks;

namespace LETin.Billingo.Api
{
    public interface IBlocksRepository
    {
        Task<ICollection<BillingoIdWrapper<InvoiceBlock>>> GetAvailableInvoiceBlocksAsync();
    }
}