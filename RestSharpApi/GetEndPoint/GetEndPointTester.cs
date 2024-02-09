using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RestSharpApi
{
    [TestClass]
    public class GetEndPointTester
    {        
        [TestMethod]
        public async Task TestingGetEndPointUsingGetAsync()
        {
            IRestClient restClient = new RestClient("https://reqres.in/");
            RestRequest restRequest = new RestRequest(@"api/users/2", Method.Get);
            restRequest.AddHeader("Accept", "application/json");

            CancellationToken cancellationToken = new CancellationToken();
            Root root = await restClient.GetAsync<Root>(restRequest, cancellationToken);
            if(root != null && root.data != null && root.support != null)
            {
                Data data = root.data;
                if (data != null)
                {
                    Console.WriteLine("\n[REST RESPONSE DATA] =============");
                    Console.WriteLine($"ID: {data.id}" +
                        $"\nEmail: {data.email}" +
                        $"\nFirst Name: {data.first_name}" +
                        $"\nLast Name: {data.last_name}" +
                        $"\nAvatar: {data.avatar}");
                }
            }
        }

        [TestMethod]
        public async Task TestGetEndPointUsingExecuteGetAsync()
        {
            IRestClient restClient = new RestClient("https://reqres.in/");
            RestRequest restRequest = new RestRequest("api/users/2", Method.Get);

            // We can also, Deserialize the response object from within the restclient object using Deserialize method
            //RestResponse<Root> restResponse = restClient.Deserialize<Root>(await restClient.ExecuteGetAsync(restRequest));
            //Data data = restResponse.Data.data;

            RestResponse restResponse = await restClient.ExecuteGetAsync<Root>(restRequest);
            if (restResponse != null && restResponse.IsSuccessful)
            {
                Console.WriteLine("[REST RESPONSE DETAILS] ==============");
                Console.WriteLine($"Response status: {restResponse.StatusCode}");
                Console.WriteLine($"Response status code: {(int)restResponse.StatusCode}");
                Console.WriteLine($"Response content: {restResponse.Content}");
            }

            Data data = (await restClient.GetAsync<Root>(restRequest)).data;
            if (data != null )
            {
                Console.WriteLine("\n[REST RESPONSE DATA] =============");
                Console.WriteLine($"ID: {data.id}" +
                    $"\nEmail: {data.email}" +
                    $"\nFirst Name: {data.first_name}" +
                    $"\nLast Name: {data.last_name}" +
                    $"\nAvatar: {data.avatar}");
            }
        }
    }
}
