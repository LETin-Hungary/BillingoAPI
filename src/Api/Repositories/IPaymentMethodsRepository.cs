using System.Collections.Generic;
using System.Threading.Tasks;

namespace LETin.Billingo.Api
{
    public interface IPaymentMethodsRepository
    {
        Task<ICollection<BillingoIdWrapper<PaymentMethod>>> GetListAsync(string langcode);
    }
}