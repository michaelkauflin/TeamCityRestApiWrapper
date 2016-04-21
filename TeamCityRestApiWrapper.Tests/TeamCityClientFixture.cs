namespace TeamCity.RestApi.Wrapper.Tests
{
    using System;

    using NUnit.Framework;

    using RestSharp;

    [TestFixture]
    public class TeamCityClientFixture
    {
        [TestCase("http://teamcity.codebetter.com/", ExpectedResult = "http://teamcity.codebetter.com/")]
        [TestCase("", ExpectedResult = "http://teamcity.codebetter.com/")]
        [TestCase(null, ExpectedResult = "http://teamcity.codebetter.com/")]
        public string InitClientTest(string url)
        {
            var teamCityClient = string.IsNullOrEmpty(url) ? new TeamCityClient() : new TeamCityClient(url);
            RestClient restClient = teamCityClient.RestClient;

            Assert.That(restClient, Is.Not.Null);

            Uri baseUrl = restClient.BaseUrl;
            Console.WriteLine(baseUrl);

            return baseUrl.AbsoluteUri;
        }
    }
}
