using System.Runtime.Serialization;

namespace RestSharpApi
{
    //public class JsonUser
    //{
    //    [JsonPropertyName("id")]
    //    public int Id { get; set; }
    //    [JsonPropertyName("email")]
    //    public string Email { get; set; }
    //    [JsonPropertyName("first_name")]
    //    public string FirstName { get; set; }
    //    [JsonPropertyName("last_name")]
    //    public string LastName { get; set; }
    //    [JsonPropertyName("avatar")]
    //    public string Avatar { get; set; }
    //}
    [DataContract]
    public class Data
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string first_name { get; set; }
        [DataMember]
        public string last_name { get; set; }
        [DataMember]
        public string avatar { get; set; }
        [DataMember]
        public string job { get; set; }
    }
    [DataContract]
    public class Root
    {
        [DataMember]
        public Data data { get; set; }
        [DataMember]
        public Support support { get; set; }
    }
    [DataContract]
    public class Support
    {
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string text { get; set; }
    }

    public static class DataHelper
    {
        public static Data GetDataObject()
        {
            Data data = new Data()
            {
                name = "Sushil Zad",
                job = "SDET Automation Tester",
                email = "sushil.zad@gmail.com"
            };
            return data;
        }
    }
}
