using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecflowBDD.POCO.JsonBodyRequests;
using System;
using TechTalk.SpecFlow;

namespace SpecflowBDD.Steps
{
    [Binding]
    public class APISteps
    {
        int statusCode;
        ReadBookingsIds getBookingIds = new ReadBookingsIds();
        CreateBooking createBooking = new CreateBooking();
        bool result = false;

        #region When

        [When(@"sends Get Method")]
        public void WhenSendsGetMethod()
        {
            statusCode = getBookingIds.GetBookingIds();
        }
        
        [When(@"sends Post Method")]
        public void WhenSendsPostMethod()
        {
            statusCode = createBooking.CreateBrandNewBooking();
        }

        #endregion

        #region Then

        [Then(@"the response code should be (.*)")]
        public void ThenTheResponseCodeShouldBe(int expectedStatusCode)
        {
            if (expectedStatusCode == statusCode)
            {
                result = true;
            }
            Assert.IsTrue(result);
            result = false;
        }

        #endregion
    }
}
