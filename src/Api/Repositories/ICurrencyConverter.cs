using System.Threading.Tasks;

namespace LETin.Billingo.Api
{
    public interface ICurrencyConverter
    {
        Task<CurrencyConverterValue> ConvertAsync(string from, string to, double value);
    }
}