using RestSharp;
using System;


namespace SpecflowBDD.POCO.JsonBodyRequests
{
    public class CreateBooking
    {
        private string postBrandNewBooking = "https://restful-booker.herokuapp.com/booking";

        string createBrandNewBooking = "{ \r\n" +
                                          "\"firstname\": \"JQ\",\r\n" +
                                          "\"lastname\": \"Test\",\r\n" +
                                          "\"totalprice\": \"4000\",\r\n" +
                                          "\"depositpaid\": \"true\",\r\n" +
                                          "\"bookingdates\":\r\n" +
                                            "{\r\n" +
                                                "\"checkin\": \"2018-01-01\",\r\n" +
                                                "\"checkout\": \"2019-01-01\"\r\n" +
                                            "},\r\n" +
                                           "\"additionalneeds\": \"Breakfast\"\r\n" +
                                         "}";


        public int CreateBrandNewBooking()
        {
            RestClient restClient = new RestClient();
            RestRequest request = new RestRequest()
            {
                Resource = postBrandNewBooking,
                Method = Method.POST,
                RequestFormat = DataFormat.Json
            };

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "*/*");
            request.AddJsonBody(createBrandNewBooking);

            IRestResponse response = restClient.Execute(request);
            return (int)response.StatusCode;
        }
    }
}
