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

namespace HttpClientRestApi.GetEndPoint
{
    [TestClass]
    public class GetEndPointTester
    {
        private string getEndPoint = "https://reqres.in/api/users/2";

        [TestMethod]
        public void TestGetEndPointUsingStringUrl()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.GetAsync(getEndPoint);

            httpClient.Dispose();
        }

        [TestMethod]
        public void TestGetEndPointUsingUri()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage httpResponseMessage = httpClient.GetAsync(getEndPoint).Result)
                {
                    Console.WriteLine(httpResponseMessage.StatusCode.ToString());
                    Console.WriteLine((int)httpResponseMessage.StatusCode);
                    Console.WriteLine(httpResponseMessage.Content.ReadAsStringAsync().Result);
                }
            }
        }

        [TestMethod]
        public void TestGetEndPointUsingUriPageNotFound404Error()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpResponseMessage httpResponseMessage = httpClient.GetAsync(getEndPoint + "//random").Result)
                {
                    Console.WriteLine(httpResponseMessage.StatusCode.ToString());
                    Console.WriteLine((int)httpResponseMessage.StatusCode);
                    Console.WriteLine(httpResponseMessage.Content.ReadAsStringAsync().Result);
                }
            }
        }

        [TestMethod]
        public void TestGetEndPointUsingHttpRequestHeaders()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpRequestHeaders keyValuePairs = httpClient.DefaultRequestHeaders;
                //keyValuePairs.Add("Accept", "application/xml");
                MediaTypeWithQualityHeaderValue acceptXml = new MediaTypeWithQualityHeaderValue("application/xml");
                keyValuePairs.Accept.Add(acceptXml);

                using (HttpResponseMessage httpResponseMessage = httpClient.GetAsync(getEndPoint).Result)
                {
                    Console.WriteLine(httpResponseMessage.StatusCode.ToString());
                    Console.WriteLine((int)httpResponseMessage.StatusCode);
                    Console.WriteLine(httpResponseMessage.Content.ReadAsStringAsync().Result);
                }
            }
        }

        [TestMethod]
        public void TestGetEndPointUsingHttpRequestMessage()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage())
                {
                    httpRequestMessage.RequestUri = new Uri(getEndPoint);
                    httpRequestMessage.Method = HttpMethod.Get;
                    httpRequestMessage.Headers.Add("Accept", "application/json");

                    using (HttpResponseMessage httpResponseMessage = httpClient.SendAsync(httpRequestMessage).Result)
                    {
                        Console.WriteLine(httpResponseMessage.StatusCode.ToString());
                        Console.WriteLine((int)httpResponseMessage.StatusCode);
                        Console.WriteLine(httpResponseMessage.Content.ReadAsStringAsync().Result);
                    }
                }
            }
        }

        [TestMethod]
        public void TestGetEndPointUsingHttpRequestMessageAndDeserializationIntoJsonObject()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage())
                {
                    httpRequestMessage.RequestUri = new Uri(getEndPoint);
                    httpRequestMessage.Method = HttpMethod.Get;
                    httpRequestMessage.Headers.Add("Accept", "application/json");

                    using (HttpResponseMessage httpResponseMessage = httpClient.SendAsync(httpRequestMessage).Result)
                    {
                        Console.WriteLine(httpResponseMessage.StatusCode.ToString());
                        Console.WriteLine((int)httpResponseMessage.StatusCode);
                        string jsonContent = httpResponseMessage.Content.ReadAsStringAsync().Result;
                        Console.WriteLine(jsonContent);

                        Data data = JsonConvert.DeserializeObject<Root>(jsonContent).data;
                        Console.WriteLine("\n[DESERIALIZED DATA] =============");
                        Console.WriteLine($"ID: {data.id}" +
                            $"\nEmail: {data.email}" +
                            $"\nFirst Name: {data.first_name}" +
                            $"\nLast Name: {data.last_name}" +
                            $"\nAvatar: {data.avatar}");
                    }
                }
            }
        }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Data
    {
        public int id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string avatar { get; set; }
    }

    public class Root
    {
        public Data data { get; set; }
        public Support support { get; set; }
    }

    public class Support
    {
        public string url { get; set; }
        public string text { get; set; }
    }
}
