using System.Collections.Generic;
using System.Threading.Tasks;

namespace LETin.Billingo.Api
{
    public class PaymentMethodsRepository : IPaymentMethodsRepository
    {
        private readonly BillingoWebAPI api;

        public PaymentMethodsRepository(BillingoWebAPI api)
        {
            this.api = api;
        }

        public async Task<ICollection<BillingoIdWrapper<PaymentMethod>>> GetListAsync(string langcode)
        {
            return await api.GetJsonAsync<ICollection<BillingoIdWrapper<PaymentMethod>>>($"/payment_methods/{langcode}");
        }
    }
}
