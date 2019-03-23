using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace LETin.Billingo.Api.Test
{
    public class PaymentMethodsTest : TestBase
    {
        private readonly IPaymentMethodsRepository paymentMethodsRepository;

        public PaymentMethodsTest() : base()
        {
            paymentMethodsRepository = new PaymentMethodsRepository(billingoApi);
        }
        [Fact]
        public async Task GetAsync()
        {
            var result = await paymentMethodsRepository.GetListAsync("hu");
            Assert.NotNull(result);
        }
    }
}
