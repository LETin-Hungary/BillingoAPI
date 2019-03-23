using LETin.BillingoAPI.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LETin.Billingo.Api
{
    public class InvoicesRepository : IInvoicesRepository
    {
        private readonly BillingoWebAPI api;

        public InvoicesRepository(BillingoWebAPI api)
        {
            this.api = api;
        }
        public async Task<ICollection<BillingoIdWrapper<Invoice>>> GetListAsync(int page = 1, int maxPerPage = 20)
        {
            return await api.GetJsonAsync<ICollection<BillingoIdWrapper<Invoice>>>($"/invoices?page={page}&max_per_page={maxPerPage}");
        }
        public async Task<BillingoIdWrapper<Invoice>> GetAsync(int id)
        {
            return (await api.GetJsonAsync<ICollection<BillingoIdWrapper<Invoice>>>($"/invoices/{id}")).Single();
        }
        public async Task<BillingoIdWrapper<Invoice>> CreateAsync(Invoice invoice)
        {
            return await api.PostJsonAsync<BillingoIdWrapper<Invoice>>("/invoices", invoice);
        }
        public async Task<InvoiceCode> CreateDownloadLinkAsync(int id)
        {
            return await api.GetJsonAsync<InvoiceCode>($"/invoices/{id}/code");
        }
        public async Task GenerateNormalFromProformaAsync(int id)
        {
            await api.GetJsonAsync($"/invoices/{id}/generate");
        }
        public async Task<Stream> DownloadPDF(int id)
        {
            var response = await api.GetRawAsync($"/invoices/{id}/download");
            return await response.Content.ReadAsStreamAsync();
        }
        public async Task<BillingoIdWrapper<Invoice>> CancelAsync(int id)
        {
            return await api.GetJsonAsync<BillingoIdWrapper<Invoice>>($"/invoices/{id}/cancel");
        }
        public async Task SendEmailAsync(int id)
        {
            await api.GetJsonAsync($"/invoices/{id}/send");
        }
        public async Task<SavedPay> PayAsync(int id, InvoicePay pay)
        {
            return await api.PostJsonAsync<SavedPay>($"/invoices/{id}/pay", pay);
        }
        public async Task<SavedPay> UndoPayAsync(int id)
        {
            return await api.DeleteJsonAsync<SavedPay>($"/invoices/{id}/pay");
        }
    }
}