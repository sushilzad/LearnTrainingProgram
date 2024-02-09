using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpApi.PutEndPoint
{
    [TestClass]
    public class PutEndPointTester
    {
        string postUrl = "https://reqres.in/api/users";
        string putUrl = "https://reqres.in/api/users/";
        //string getUrl = "https://reqres.in/api/users/";
        int newlyCreatedRecordId = -1;

        [TestMethod]
        public async Task PutEndPointTesterUsingRestSharp()
        {
        // STEP 1. Use the POST method to create some new records
            IRestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest()
            {
                Resource = postUrl
            };
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddBody(DataHelper.GetDataObject());
            RestResponse<Data> restResponse = await restClient.ExecutePostAsync<Data>(restRequest);
            Assert.AreEqual(201, (int)restResponse.StatusCode);
            Assert.AreEqual(true, restResponse.IsSuccessful);
            newlyCreatedRecordId = restResponse.Data.id;


        // STEP 2. Use the PUT method to update this newly created record
            restRequest = new RestRequest()
            {
                Resource = putUrl + newlyCreatedRecordId
            };
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Accept", "application/json");
            restRequest.RequestFormat = DataFormat.Json;
            Data updatedData = restResponse.Data;
            updatedData.id = newlyCreatedRecordId;
            updatedData.email = "sushilsunil_zad@epam.com";
            updatedData.first_name = "Sushil Sunil";
            updatedData.last_name = "Zad";
            updatedData.job = "EPAM systems";
            updatedData.name = "Sushi Sunil Zad";
            restRequest.AddBody(updatedData);
            restResponse = await restClient.ExecutePutAsync<Data>(restRequest);
            Assert.AreEqual(200, (int)restResponse.StatusCode);
            Assert.AreEqual(true, restResponse.IsSuccessful);


        // STEP 3. Use the GET method to fetch this updated record for verification
            // restClient = new RestClient();
            // restRequest = new RestRequest(getUrl + newlyCreatedRecordId, Method.Get);
            // Data data = (await restClient.GetAsync<Root>(restRequest)).data;
            // Assert.AreEqual(updatedData, data);
        }
    }
}
