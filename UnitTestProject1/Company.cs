using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    class Company : BaseRestApi
    {
        public string companyPath;
        public string companyIdPath;
        public string companyName;

        RestClient client;
        RestRequest request;

        public Company()
        {
            companyPath = "/api/automation/companies";
            companyIdPath = "/api/automation/companies/id/";
            companyName = "TestCompany" + GetRandomNumber();
            client = new RestClient(baseUrl);  
                     
        }

        public string getToken()
        {
            var tokenResponse = GenerateToken();
            var tokenContent = tokenResponse.Content;
            var bearer = RetrieveToken(tokenResponse);
            //validate that token was created and retrieved successfully
            Console.WriteLine(bearer);
            return bearer;
        }
        
        
        public IRestResponse PostCompany()
        {        
            request = new RestRequest(companyPath, Method.POST);
            request.AddHeader("Content-Type", contentType);
            request.AddHeader("Authorization", authorizationType + getToken());
            var body = new { Name = companyName };
            request.AddJsonBody(body);
            return client.Execute(request);
        }

        //Create GET All Companies request 
        public IRestResponse GetCompanies()
        {
            request = new RestRequest(companyPath, Method.GET);
            request.AddHeader("Content-Type", contentType);
            request.AddHeader("Authorization", authorizationType + getToken());
            return client.Execute(request);
        }

        ////Create GET Company BY ID request 
        //public IRestResponse GetCompanyById()
        //{
        //    request = new RestRequest(companyPath + companyId, Method.GET);
        //    request.AddHeader("Content-Type", contentType);
        //    request.AddHeader("Authorization", authorizationType + getToken());
        //    return client.Execute(request);
        //}

        ////Create DELETE request
        //public IRestResponse Delete()
        //{
        //    request = new RestRequest(companyPath + companyId, Method.DELETE);
        //    request.AddHeader("Authorization", authorizationType + getToken());
        //    return client.Execute(request);
        //}
    }
}
