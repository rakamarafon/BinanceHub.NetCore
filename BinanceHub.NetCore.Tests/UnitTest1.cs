namespace BinanceHub.NetCore.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
            RestHub hub = new RestHub("", "");
            var test = await hub.PublicAPI.CheckServerTime();
            Assert.Pass();
        }
    }
}