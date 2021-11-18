using System.Net;
using RestSharp;
using RestSharp.Authenticators;
using SeleniumWebdriver.Resources;

namespace SeleniumWebdriver.ComponentHelper
{
    public class ApiHelper
    {

        public static IRestRequest getRepoPayload(string repoId)
        {

            IRestRequest request = new RestRequest(API.getRepo, Method.GET)
                .AddParameter("owner", "marroyave813", ParameterType.UrlSegment)
                .AddParameter("repo", repoId, ParameterType.UrlSegment);

            return request;
        }

        public static RestClient startPayload()
        {
            RestClient client = new RestClient("https://api.github.com");
            client.Authenticator = new HttpBasicAuthenticator("mauricioarroyave@gmail.com", "");

            return client;
        }

        public static IRestResponse executePayload(RestClient client, IRestRequest request)
        {
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static int getResponseCode(IRestResponse response)
        {
            HttpStatusCode statusCode = response.StatusCode;
            int numericStatusCode = (int)statusCode;
            return numericStatusCode;
        }
    }
}
