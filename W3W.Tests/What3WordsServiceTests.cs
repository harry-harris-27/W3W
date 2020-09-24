using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W3W.Tests
{
    [TestClass]
    public class What3WordsServiceTests
    {

        private readonly IWhat3WordsService what3WordsService;

        public What3WordsServiceTests()
        {
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets<What3WordsServiceTests>()
                .Build();

            string apiKey = configuration["what3wordsApiKey"];
            what3WordsService = new What3WordsService(apiKey);
        }


        [TestMethod]
        [DataRow(42.998747, -81.254366, "offshore.bitters.voltage")]
        [DataRow(51.520847, -0.195521, "filled.count.soap")]
        [DataRow(51.521251, -0.203586, "index.home.raft")]
        public async Task Test_ConvertTo3WordAddress(double latitude, double longitude, string expectedWords)
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
        public async Task Test_ConvertToCoordinates(string words, double expectedLatitude, double expectedLongitude)
        {
            var result = await what3WordsService.ConvertAsync(words);

            Assert.AreEqual(words, result.Words);
            Assert.AreEqual(expectedLatitude, result.Coordinates.Latitude);
            Assert.AreEqual(expectedLongitude, result.Coordinates.Longitude);
        }

        [TestMethod]
        public async Task Test_AutoSuggestWithBoundingBox()
        {
            var expectedSuggestions = new[]
            {
                new What3WordsSuggestion("GB", "Brixton Hill, London", "plan.clips.area", 1, "en"),
                new What3WordsSuggestion("GB", "Skegness, Lincs.", "plan.clips.army", 2, "en"),
                new What3WordsSuggestion("GB", "Borehamwood, Herts.", "plan.clips.arts", 3, "en")
            };
            
            var options = new What3WordsAutoSuggestOptionsBuilder()
                .ClipToBoundingBox(new LatLng(50, -4), new LatLng(54, 2))
                .CreateInstance();
            
            var result = await what3WordsService.AutoSuggestAsync("plan.clips.a", options);
            var suggestions = result.Suggestions.OrderBy(x => x.Rank).ToList();

            Assert.AreEqual(suggestions.Count, 3);

            for (int i = 0; i < suggestions.Count; i++)
            {
                What3WordsSuggestion expectedSuggestion = expectedSuggestions[i];
                What3WordsSuggestion actualSuggestion = suggestions[i];

                Assert.AreEqual(expectedSuggestion.Country, actualSuggestion.Country);
                Assert.AreEqual(expectedSuggestion.NearestPlace, actualSuggestion.NearestPlace);
                Assert.AreEqual(expectedSuggestion.Words, actualSuggestion.Words);
                Assert.AreEqual(expectedSuggestion.Rank, actualSuggestion.Rank);
                Assert.AreEqual(expectedSuggestion.Language, actualSuggestion.Language);
            }
        }

        [TestMethod]
        public async Task Test_AvailableLanguagesReturnsNotEmpty()
        {
            var result = await what3WordsService.AvailableLanguagesAsync();
            Assert.IsTrue(result.Languages.Any());
        }
    }
}
