namespace TeamCity.RestApi.Wrapper
{
    using System;

    using RestSharp;

    public class TeamCityClient
    {
        private readonly RestClient _restClient;

        public TeamCityClient() : this(GetRestClient())
        {}

        public TeamCityClient(string url) : this(new RestClient(url))
        { }

        public TeamCityClient(RestClient restClient)
        {
            _restClient = restClient;
        }

        public RestClient RestClient { get { return _restClient; }}

        private static RestClient GetRestClient()
        {
            string user = Environment.GetEnvironmentVariable("TeamCity.User");
            string pwd = Environment.GetEnvironmentVariable("TeamCity.Pwd");
            string url = Environment.GetEnvironmentVariable("TeamCity.Url");

            if (!string.IsNullOrEmpty(url))
            {
                return new RestClient(url);
            }
            
            return new RestClient("http://teamcity.codebetter.com/");
        }
    }
}
