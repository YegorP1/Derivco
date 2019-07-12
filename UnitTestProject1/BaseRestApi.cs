
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;

namespace UnitTestProject1
{

    class BaseRestApi
    {
        RestClient client;
        RestRequest request;

        //Define Base URL for all requests and Body for generate token
        internal protected string baseUrl = "https://mobilewebserver9-pokertest8ext.installprogram.eu/TestApi";
        private string tokenBody = "grant_type=password&username=testName&password=test";

        internal protected string contentType = "application/json";
        internal protected string authorizationType = "Bearer ";
        //Genererate randon int for creation unique value in request body  
        public static int GetRandomNumber()
        {
            var random = new Random();
            return random.Next(); 
        }

        //Generate OAuth2 Token for all requests
        public IRestResponse GenerateToken()
        {
            client = new RestClient(baseUrl);      
            request = new RestRequest("/token", Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            string encodedBody = string.Format(tokenBody);
            request.AddParameter("application/x-www-form-urlencoded", encodedBody, ParameterType.RequestBody);
            return client.Execute(request);
        }

        //Retrieve bearer token value
        public string RetrieveToken(IRestResponse response)
        {
            var content = response.Content;
            JObject obj = JObject.Parse(content);
            JToken access = obj.SelectToken("access_token");
            return access.ToString();         
        }

        //Retrieve ID value from Json
        public string RetrieveId(string inputJson)
        {
            string key = inputJson.Substring(inputJson.IndexOf("Id"));
            key = key.Substring(key.IndexOf("\""), key.IndexOf(",") - key.IndexOf("\""));
            key = key.Trim('\"').Substring(1);
            return key;
        }

        //Assert function that verify Response Status Code and print it
        public void AssertStatusCode(IRestResponse response)
        {
            try
            {
                var statusCode = response.StatusCode.ToString();
                NUnit.Framework.Assert.AreEqual(statusCode, "OK");
                Console.WriteLine(statusCode);
            }
            catch (AssertFailedException)
            {
                Console.WriteLine("Assertion Failed");
            }
        }

        public IRestResponse GetAll(string bearerToken, string path)
        {
            client = new RestClient(baseUrl);
            request = new RestRequest(path, Method.GET);
            request.AddHeader("Content-Type", contentType);
            request.AddHeader("Authorization", authorizationType + bearerToken);
            return client.Execute(request);
        }

        public IRestResponse GetById(string bearerToken, string path, string id)
        {
            client = new RestClient(baseUrl);
            request = new RestRequest(path + id, Method.GET);
            request.AddHeader("Content-Type", contentType);
            request.AddHeader("Authorization", authorizationType + bearerToken);
            return client.Execute(request);
        }

    }
}
