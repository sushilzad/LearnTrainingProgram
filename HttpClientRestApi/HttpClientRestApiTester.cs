using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;

namespace HttpClientRestApi
{
    [TestClass]
    public class HttpClientRestApiTester
    {
        [TestMethod]
        public void TestMethod1()
        {
            HttpClient httpClient = new HttpClient();


            httpClient.Dispose();
        }
    }
}
