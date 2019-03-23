using System.Collections.Generic;
using System.Threading.Tasks;

namespace LETin.Billingo.Api
{
    public class VATRepository : IVATRepository
    {
        private readonly BillingoWebAPI api;

        public VATRepository(BillingoWebAPI api)
        {
            this.api = api;
        }

        public async Task<ICollection<BillingoIdWrapper<VAT>>> GetListAsync()
        {
            return await api.GetJsonAsync<ICollection<BillingoIdWrapper<VAT>>>($"/vat");
        }
    }
}
