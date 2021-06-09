using NUnit.Framework;
using BlazorWeatherAPI.Helpers;

namespace WeatherAPITests
{
    public class Tests
    {               
        [Test]
        [TestCase("https//metaweather.com", false)]
        [TestCase("https://metaweather.com", true)]
        [TestCase("https//metaweather.co.uk", false)]
        public void TestWeatherURL(string request, bool expected)
        {
            Assert.AreEqual(URIValid.validURI(request), expected);
        }
    }
}