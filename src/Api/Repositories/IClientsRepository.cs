using System.Collections.Generic;
using System.Threading.Tasks;

namespace LETin.Billingo.Api
{
    public interface IClientsRepository
    {
        Task<BillingoIdWrapper<Client>> CreateAsync(Client client);
        Task DeleteAsync(int id);
        Task<BillingoIdWrapper<Client>> GetAsync(int id);
        Task<ICollection<BillingoIdWrapper<Client>>> GetListAsync(int page = 1, int maxPerPage = 20);
        Task<BillingoIdWrapper<Client>> ModifyAsync(int id, Client client);
    }
}