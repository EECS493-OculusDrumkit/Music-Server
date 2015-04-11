using DrumKitUtil;
using NUnit.Framework;

namespace DrumKitUtilTest
{
    [TestFixture]
    public class Http
    {
        private string _baseUrl;
        private DrumKit _drum;

        [TestFixtureSetUp]
        public void Setup()
        {
            _baseUrl = "http://drumkit.ngrok.com";
            _drum = new DrumKit(_baseUrl);
        }

        [TestFixtureTearDown]
        public void Teardown()
        {
            
        }

        [Test]
        public void HttpCrashTest()
        {
            _drum.PlayCrashCymbol(127, 1000);
        }

        [Test]
        public void HttpBassTest()
        {
            _drum.PlayBassDrum(127, 1000);
        }

        [Test]
        public void HttpSnareTest()
        {
            _drum.PlaySnareDrum(127, 1000);
        }

        [Test]
        public void HttpTomTest()
        {
            _drum.PlayTom(127, 1000);
        }

        [Test]
        public void HttpHihatTest()
        {
            _drum.PlayHiHat(127, 1000);
        }

        [Test]
        public void HttpCowbellTest()
        {
            _drum.PlayCowbell(127, 1000);
        }

        [Test]
        public void HttpChannelTest()
        {
            _drum.ChangeDrumPack(2);
        }
    }
}
