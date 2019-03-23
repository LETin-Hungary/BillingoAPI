using LETin.Billingo.Api;
using LETin.Billingo.AspNetCore;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BillingoAspNetCoreDI
    {
        public static IServiceCollection AddBillingo(this IServiceCollection services)
        {
            services.AddScoped(c =>
            {
                var options = c.GetService<IOptionsSnapshot<BillingoOptions>>().Value;
                return new BillingoWebAPI(options.IssuerUri,options.PublicKey, options.PrivateKey, options.TokenExpireSeconds);
            });
            services.AddTransient<IBlocksRepository, BlocksRepository>();
            services.AddTransient<IClientsRepository, ClientsRepository>();
            services.AddTransient<ICurrencyConverter, CurrencyConverter>();
            services.AddTransient<IInvoicesRepository, InvoicesRepository>();
            services.AddTransient<IPaymentMethodsRepository, PaymentMethodsRepository>();
            services.AddTransient<IVATRepository, VATRepository>();
            return services;
        }
    }
}
