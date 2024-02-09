using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpApi.RestPostEndPoint
{
    [TestClass]
    public class PostEndPointTester
    {
        private string postUrl = @"https://reqres.in/api/users";

        [TestMethod]
        public void PostEndPointTest()
        {
            string jsonData = "{" +
                //"\"id\": " + 193 +
                "\"name\": \"morpheus\"," +
                "\"job\": \"leader\"}";

            IRestClient restClient = new RestClient();
            RestRequest request = new RestRequest()
            {
                Resource = postUrl
            };
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/xml");
            request.AddBody(jsonData);

            RestResponse restResponse = restClient.Post(request);
            if (restResponse != null && restResponse.IsSuccessful || restResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("[REST RESPONSE DETAILS] ==============");
                Console.WriteLine($"Response status: {restResponse.StatusCode}");
                Console.WriteLine($"Response status code: {(int)restResponse.StatusCode}");
                Console.WriteLine($"Response content: {restResponse.Content}");
            }
        }

        [TestMethod]
        public async Task PostEndPointTestUsingExecutePost()
        {
            string jsonData = "{" +
                "\"id\": " + new Random().Next(1000) +    // ==> THIS IS AN ERRONEOUS STATEMENT BUT ExecutePostAsync() SWALLOWS IT OUT
                "\"name\": \"morpheus\"," +
                "\"job\": \"leader\"}";

            IRestClient restClient = new RestClient();
            RestRequest request = new RestRequest()
            {
                Resource = postUrl
            };
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/xml");
            request.AddBody(jsonData);

            RestResponse restResponse = await restClient.ExecutePostAsync(request);
            if (restResponse != null && restResponse.IsSuccessful || restResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("[REST RESPONSE DETAILS] ==============");
                Console.WriteLine($"Response status: {restResponse.StatusCode}");
                Console.WriteLine($"Response status code: {(int)restResponse.StatusCode}");
                Console.WriteLine($"Response content: {restResponse.Content}");
            }
            else
            {
                Console.WriteLine("BAD REQUEST!!");
                Console.WriteLine("[REST RESPONSE DETAILS] ==============");
                Console.WriteLine($"Response status: {restResponse.StatusCode}");
                Console.WriteLine($"Response status code: {(int)restResponse.StatusCode}");
                Console.WriteLine($"Response content: {restResponse.Content}");
            }
        }

        [TestMethod]
        public async Task PostEndPointTestUsingRequestFormatDeserializingFromObjectToString()
        {
            IRestClient restClient = new RestClient();
            RestRequest request = new RestRequest()
            {
                Resource = postUrl
            };
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/xml");
            request.AddBody(DataHelper.GetDataObject());

            RestResponse restResponse = await restClient.PostAsync(request);
            if (restResponse != null && restResponse.IsSuccessful || restResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("[REST RESPONSE DETAILS] ==============");
                Console.WriteLine($"Response status: {restResponse.StatusCode}");
                Console.WriteLine($"Response status code: {(int)restResponse.StatusCode}");
                Console.WriteLine($"Response content: {restResponse.Content}");
            }
            else
            {
                Console.WriteLine("BAD REQUEST!!");
                Console.WriteLine("[REST RESPONSE DETAILS] ==============");
                Console.WriteLine($"Response status: {restResponse.StatusCode}");
                Console.WriteLine($"Response status code: {(int)restResponse.StatusCode}");
                Console.WriteLine($"Response content: {restResponse.Content}");
            }
        }
    }
}
