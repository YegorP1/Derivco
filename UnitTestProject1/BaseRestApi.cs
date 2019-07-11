
using Newtonsoft.Json.Linq;
using RestSharp;
using System;

namespace UnitTestProject1
{
 
        class BaseRestApi
    {
        public RestClient _client;
        public RestRequest _request;
        public IRestResponse _response;
        public JToken _access;
        public string _id;

        public string _baseUrl = "https://mobilewebserver9-pokertest8ext.installprogram.eu/TestApi";
        public string _tokenBody = "grant_type=password&username=testName&password=test";
        public int _random = GetRandomNumber();

        public static int GetRandomNumber()
        {
            var random = new Random();
            return random.Next(); 
        }


        //Generate OAuth2 Token
        public IRestResponse GenerateToken()
        {
            _client = new RestClient(_baseUrl);      
            _request = new RestRequest("/token", Method.POST);
            _request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            string encodedBody = string.Format(_tokenBody);
            _request.AddParameter("application/x-www-form-urlencoded", encodedBody, ParameterType.RequestBody);

            return _client.Execute(_request);
        }

        //Retrieve bearer token 
        public string RetrieveToken(IRestResponse response)
        {
            var content = response.Content;
            JObject obj = JObject.Parse(content);
            _access= obj.SelectToken("access_token");
            return _access.ToString();         
        }

        //Create POST request
        public IRestResponse PostRequest(string bearerToken)
        {
            _client = new RestClient(_baseUrl);
            _request = new RestRequest("/api/automation/companies", Method.POST);
            _request.AddHeader("Content-Type", "application/json");
            _request.AddHeader("Authorization", "Bearer " + bearerToken);
             var body = new { Name = "TestCompany" + _random };
            _request.AddJsonBody(body);

            return _client.Execute(_request);
        }

        //Create GET request
        public IRestResponse GetRequest(string bearerToken)
        {
            _client = new RestClient(_baseUrl);
            _request = new RestRequest("/api/automation/companies", Method.GET);
            _request.AddHeader("Content-Type", "application/json");
            _request.AddHeader("Authorization", "Bearer " + bearerToken);

            return _client.Execute(_request);
        }

        //Create GET BY ID request
        public IRestResponse GetByIdRequest(string bearerToken, string inputId)
        {
            _client = new RestClient(_baseUrl);
            _request = new RestRequest("/api/automation/companies/id/" + inputId, Method.GET);
            _request.AddHeader("Authorization", "Bearer " + bearerToken);

            return _client.Execute(_request);
        }

        //Retrieve ID  
        public string RetrieveId(string inputJson)
        {
            string key = inputJson.Substring(inputJson.IndexOf("Id"));
            key = key.Substring(key.IndexOf("\""), key.IndexOf(",") - key.IndexOf("\""));
            key = key.Trim('\"').Substring(1);

            return key;
        }

        //Create DELETE request
        public IRestResponse DeleteRequest(string bearerToken, string inputId)
        {
            _client = new RestClient(_baseUrl);
            _request = new RestRequest("/api/automation/companies/id/" + inputId, Method.DELETE);
            _request.AddHeader("Authorization", "Bearer " + bearerToken);

            return _client.Execute(_request);
        }


    }
}
