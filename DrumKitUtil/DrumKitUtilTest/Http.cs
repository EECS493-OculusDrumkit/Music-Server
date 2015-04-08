using System;
using System.Dynamic;
using DrumKitUtil;
using NUnit.Framework;

namespace DrumKitUtilTest
{
    [TestFixture]
    public class Http
    {
        private string baseUrl;
        private DrumKit drum;

        [TestFixtureSetUp]
        public void Setup()
        {
            baseUrl = "http://drumkit.ngrok.com";
            drum = new DrumKit(baseUrl);
        }

        [TestFixtureTearDown]
        public void Teardown()
        {
            
        }

        [Test]
        public async void HttpCrashTest()
        {
            await drum.PlayCrashCymbol(127, 1000);
        }

        [Test]
        public async void HttpBassTest()
        {
            await drum.PlayBassDrum(127, 1000);
        }

        [Test]
        public async void HttpSnareTest()
        {
            await drum.PlaySnareDrum(127, 1000);
        }

        [Test]
        public async void HttpTomTest()
        {
            await drum.PlayTom(127, 1000);
        }

        [Test]
        public async void HttpHihatTest()
        {
            await drum.PlayHiHat(127, 1000);
        }

        [Test]
        public async void HttpCowbellTest()
        {
            await drum.PlayCowbell(127, 1000);
        }

        [Test]
        public async void HttpChannelTest()
        {
            await drum.ChangeDrumPack(2);
        }
    }
}
