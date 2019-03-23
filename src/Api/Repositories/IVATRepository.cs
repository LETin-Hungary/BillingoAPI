using System.Collections.Generic;
using System.Threading.Tasks;

namespace LETin.Billingo.Api
{
    public interface IVATRepository
    {
        Task<ICollection<BillingoIdWrapper<VAT>>> GetListAsync();
    }
}