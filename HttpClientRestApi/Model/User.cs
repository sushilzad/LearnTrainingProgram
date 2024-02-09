using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientRestApi.Model
{
    public class User
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("password")]
        public int Password { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonIgnore]
        public string Token { get; set; }
    }
}
