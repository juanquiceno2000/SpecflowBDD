using RestSharp;
using System;


namespace SpecflowBDD.POCO.JsonBodyRequests
{
    public class ReadBookingsIds
    {
        private string getBookingsIds = "https://restful-booker.herokuapp.com/booking";

        public int GetBookingIds()
        {
            RestClient restClient = new RestClient();
            RestRequest request = new RestRequest()
            {
                Resource = getBookingsIds,
                Method = Method.GET
            };

            IRestResponse response = restClient.Execute(request);
  
            if ((int)response.StatusCode == 200)
            {
                return (int)response.StatusCode;
            }
            else
            {
                return 0;
            }
        }
    }
}
