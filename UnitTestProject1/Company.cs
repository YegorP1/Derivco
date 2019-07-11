using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    class Company
    {
        public RestClient _client;
        public RestRequest _request;
        public IRestResponse _response;
        public JToken _access;
        public string _id;
    }
}
