using System;
using System.IO;

namespace LETin.Billingo.Api.Test
{
    public class TestBase : IDisposable
    {
        protected readonly BillingoWebAPI billingoApi;

        public TestBase()
        {
            var lines = File.ReadAllLines("../../../Configuration/config.txt");
            billingoApi = new BillingoWebAPI("localhost", lines[0], lines[1], 60);
        }

        public void Dispose()
        {
            billingoApi.Dispose();
        }
    }
}
