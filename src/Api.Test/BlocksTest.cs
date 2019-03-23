using System.Threading.Tasks;
using Xunit;

namespace LETin.Billingo.Api.Test
{
    public class BlocksTest : TestBase
    {
        private readonly IBlocksRepository blocksRepository;

        public BlocksTest() : base()
        {
            blocksRepository = new BlocksRepository(billingoApi);
        }
        [Fact]
        public async Task GetAsync()
        {
            var result = await blocksRepository.GetAvailableInvoiceBlocksAsync();
            Assert.NotNull(result);
        }
    }
}
