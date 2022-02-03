using NUnit.Framework;
using SearchImageAPI;
using System.Text.RegularExpressions;

namespace TestImageSearcher
{
    public class SearcherImageURL_canSearchedUrl
    {
        private SearchImagerURL searchImager;
        [SetUp]
        public void Setup()
        {
            searchImager = new SearchImagerURL();
        }

        [Test]
        public void Test1()
        {
            var url = searchImager.GetImageURL("Weather").Result;
            Regex regex = new Regex(@"^http");
            MatchCollection matches = regex.Matches(url);
            Assert.NotZero(matches.Count);
        }
    }
}