using LETin.BillingoAPI.Models;

namespace LETin.BillingoAPI.Utilities
{
    public static class InvoiceUtility
    {
        static string ConvertToAccessUrl(InvoiceCode code)
        {
            return $"https://www.billingo.hu/access/c:{code.Code}";
        }
    }
}