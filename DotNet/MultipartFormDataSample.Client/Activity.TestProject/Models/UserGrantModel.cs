using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Activity.TestProject.Models
{
    class UserGrantModel
    {
        private string _grantType = "password";
        [JsonProperty(PropertyName = "grant_type")]
        public string GrantType
        {
            get { return _grantType; }
            set { _grantType = value; }
        }

        private string _clientId = "D460E4FE-FD02-4CC9-9DB0-0C8CE636EE16";
        [JsonProperty(PropertyName = "client_id")]
        public string ClientId
        {
            get { return _clientId; }
            set { _clientId = value; }
        }

        private string _clientSecret = "NEE3MjgwNjlDNEVCQjJBNUJCMEE1ODQyOEFCN0E2NkM";
        [JsonProperty(PropertyName = "client_secret")]
        public string ClientSecret
        {
            get { return _clientSecret; }
            set { _clientSecret = value; }
        }

        [JsonProperty(PropertyName = "username")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
    }
}
