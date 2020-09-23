using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace W3W.Tests
{
    [TestClass]
    public class What3WordsServiceTests
    {
        private IWhat3WordsService what3WordsService;


        [TestInitialize]
        public void Setup()
        {
            what3WordsService = new What3WordsService("L7S5SD5Q");
        }


        [TestMethod]
        [DataRow(42.998747, -81.254366, "offshore.bitters.voltage")]
        [DataRow(51.520847, -0.195521, "filled.count.soap")]
        [DataRow(51.521251, -0.203586, "index.home.raft")]
        public async Task TestConvertTo3WordAddress(double latitude, double longitude, string expectedWords)
        {
            var result = await what3WordsService.ConvertAsync(latitude, longitude);

            Assert.AreEqual(latitude, result.Coordinates.Latitude);
            Assert.AreEqual(longitude, result.Coordinates.Longitude);
            Assert.AreEqual(expectedWords, result.Words);
        }

        [TestMethod]
        [DataRow("offshore.bitters.voltage", 42.998747, -81.254366)]
        [DataRow("filled.count.soap", 51.520847, -0.195521)]
        [DataRow("index.home.raft", 51.521251, -0.203586)]
        public async Task TestConvertToCoordinates(string words, double expectedLatitude, double expectedLongitude)
        {
            var result = await what3WordsService.ConvertAsync(words);

            Assert.AreEqual(words, result.Words);
            Assert.AreEqual(expectedLatitude, result.Coordinates.Latitude);
            Assert.AreEqual(expectedLongitude, result.Coordinates.Longitude);
        }
    }
}
