using System.Threading.Tasks;

namespace LETin.Billingo.Api
{
    public class CurrencyConverter : ICurrencyConverter
    {
        private readonly BillingoWebAPI api;

        public CurrencyConverter(BillingoWebAPI api)
        {
            this.api = api;
        }

        public async Task<CurrencyConverterValue> ConvertAsync(string from, string to, double value)
        {
            return await api.GetJsonAsync<CurrencyConverterValue>($"/currency?from={from}&to={to}&value={value}");
        }
    }
}
