using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using LETin.BillingoAPI.Models;

namespace LETin.Billingo.Api
{
    public interface IInvoicesRepository
    {
        Task<BillingoIdWrapper<Invoice>> CancelAsync(int id);
        Task<BillingoIdWrapper<Invoice>> CreateAsync(Invoice invoice);
        Task<InvoiceCode> CreateDownloadLinkAsync(int id);
        Task<Stream> DownloadPDF(int id);
        Task GenerateNormalFromProformaAsync(int id);
        Task<BillingoIdWrapper<Invoice>> GetAsync(int id);
        Task<ICollection<BillingoIdWrapper<Invoice>>> GetListAsync(int page = 1, int maxPerPage = 20);
        Task<SavedPay> PayAsync(int id, InvoicePay pay);
        Task SendEmailAsync(int id);
        Task<SavedPay> UndoPayAsync(int id);
    }
}