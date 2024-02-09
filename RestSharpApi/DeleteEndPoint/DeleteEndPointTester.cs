using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpApi.DeleteEndPoint
{
    [TestClass]
    public class DeleteEndPointTester
    {
        string deleteEndpoint = "https://reqres.in/api/users/2";
        [TestMethod]
        public async Task DeleteEndPointTest()
        {
            IRestClient restClient = new RestClient();
            RestRequest request = new RestRequest()
            {
                Resource = deleteEndpoint
            };
            RestResponse restResponse = await restClient.DeleteAsync(request);
            if (restResponse != null && restResponse.IsSuccessful)
            {
                Console.WriteLine("[REST RESPONSE DETAILS] ==============");
                Console.WriteLine($"Response status: {restResponse.StatusCode}");
                Console.WriteLine($"Response status code: {(int)restResponse.StatusCode}");
                Console.WriteLine($"Response content: {restResponse.Content}");
            }
        }
    }
}
