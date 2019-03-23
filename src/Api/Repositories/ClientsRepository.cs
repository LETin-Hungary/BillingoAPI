using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LETin.Billingo.Api
{
    public class ClientsRepository : IClientsRepository
    {
        private readonly BillingoWebAPI api;

        public ClientsRepository(BillingoWebAPI api)
        {
            this.api = api;
        }

        public async Task<ICollection<BillingoIdWrapper<Client>>> GetListAsync(int page = 1, int maxPerPage = 20)
        {
            return await api.GetJsonAsync<ICollection<BillingoIdWrapper<Client>>>($"/clients?page={page}&max_per_page={maxPerPage}");
        }
        public async Task<BillingoIdWrapper<Client>> GetAsync(int id)
        {
            return (await api.GetJsonAsync<ICollection<BillingoIdWrapper<Client>>>($"/clients/{id}")).Single();
        }
        public async Task<BillingoIdWrapper<Client>> CreateAsync(Client client)
        {
            return (await api.PostJsonAsync<BillingoIdWrapper<Client>>($"/clients", client));
        }
        public async Task<BillingoIdWrapper<Client>> ModifyAsync(int id, Client client)
        {
            return (await api.PostJsonAsync<BillingoIdWrapper<Client>>($"/clients/{id}", client));
        }
        public async Task DeleteAsync(int id)
        {
            await api.DeleteJsonAsync<object>($"/clients/{id}");
        }
    }
}
