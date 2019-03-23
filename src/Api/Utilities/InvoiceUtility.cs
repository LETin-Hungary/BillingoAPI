using LETin.BillingoAPI.Models;

namespace LETin.Billingo.Api
{
    public static class InvoiceUtility
    {
        public static string ConvertToAccessUrl(InvoiceCode code)
        {
            return $"https://www.billingo.hu/access/c:{code.Code}";
        }
    }
}