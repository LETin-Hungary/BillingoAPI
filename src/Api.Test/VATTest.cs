using System.Threading.Tasks;
using Xunit;

namespace LETin.Billingo.Api.Test
{
    public class VATTest : TestBase
    {
        private readonly IVATRepository vatRepository;

        public VATTest() : base()
        {
            vatRepository = new VATRepository(billingoApi);
        }
        [Fact]
        public async Task GetAsync()
        {
            var result = await vatRepository.GetListAsync();
            Assert.NotNull(result);
        }
    }
}
