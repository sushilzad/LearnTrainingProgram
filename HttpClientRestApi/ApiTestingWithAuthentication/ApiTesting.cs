using HttpClientRestApi.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientRestApi.ApiTestingWithAuthentication
{
    [TestClass]
    public class ApiTesting
    {
        private string baseUrl = "http://restapi.adequateshop.com";
        private User _registeredUser = null;

        [TestMethod]
        public async Task PerformRegistrationOfUser()
        {
            // Generate a random username
            string userName = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, 8);
            _registeredUser = new User()
            {
                Name = userName,
                Password = 123456,
                Email = $"{userName}@gmail.com",
                Token = string.Empty,
            };

            using (HttpClient client = new HttpClient())
            {
                using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage())
                {
                    httpRequestMessage.Method = HttpMethod.Post;
                    httpRequestMessage.RequestUri = new Uri(baseUrl + "/api/authaccount/registration");
                    httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    string jsonContent = JsonConvert.SerializeObject(_registeredUser, Formatting.Indented);
                    var content = new StringContent(jsonContent, null, "application/json");
                    httpRequestMessage.Content = content;

                    //using (HttpResponseMessage httpResponseMessage = await client.SendAsync(httpRequestMessage).Result)
                    using (HttpResponseMessage httpResponseMessage = await client.PostAsync(httpRequestMessage.RequestUri, httpRequestMessage.Content))
                    {
                        Console.WriteLine("[RESPONSE DETAILS] ==============");
                        Console.WriteLine($"Response status: {httpResponseMessage.StatusCode}");
                        Console.WriteLine($"Response status code: {(int)httpResponseMessage.StatusCode}");
                        Console.WriteLine($"Response content: {httpResponseMessage.Content}");
                        
                        string responseJsonString = httpResponseMessage.Content.ReadAsStringAsync().Result;
                        Console.WriteLine(responseJsonString);
                        Data responseData = JsonConvert.DeserializeObject<ResponseData>(responseJsonString).data;
                        _registeredUser.Token = responseData.Token;
                    }
                }
            }
        }
        
        [TestMethod]
        public async Task PerformLoginOperationAfterSuccessfulRegistration()
        {
            await PerformRegistrationOfUser();
            using (HttpClient client = new HttpClient())
            {
                using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage())
                {
                    httpRequestMessage.Method = HttpMethod.Post;
                    httpRequestMessage.RequestUri = new Uri(baseUrl + "/api/authaccount/login");
                    httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    Assert.IsNotNull(_registeredUser);
                    Assert.IsFalse(string.IsNullOrEmpty(_registeredUser.Token));
                    httpRequestMessage.Headers.Add("Authorization", "Bearer " + _registeredUser.Token);
                    string jsonContent = JsonConvert.SerializeObject(_registeredUser, Formatting.Indented);
                    var content = new StringContent(jsonContent, null, "application/json");
                    httpRequestMessage.Content = content;

                    using (HttpResponseMessage httpResponseMessage = await client.SendAsync(httpRequestMessage))
                    {
                        Console.WriteLine("[RESPONSE DETAILS] ==============");
                        Console.WriteLine($"Response status: {httpResponseMessage.StatusCode}");
                        Console.WriteLine($"Response status code: {(int)httpResponseMessage.StatusCode}");
                        Console.WriteLine($"Response content: {httpResponseMessage.Content}");

                        string responseJsonString = httpResponseMessage.Content.ReadAsStringAsync().Result;
                        Console.WriteLine(responseJsonString);
                        Data responseData = JsonConvert.DeserializeObject<ResponseData>(responseJsonString).data;
                        //_registeredUser.Token = responseData.Token;
                    }
                }
            }
        }
    }
}
