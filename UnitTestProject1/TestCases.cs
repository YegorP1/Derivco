using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestClass]
 
    public class TestCases
    {
        BaseRestApi restApi = new BaseRestApi();
       
        public string createToken()
        {
            var tokenResponse = restApi.GenerateToken();
            var tokenContent = tokenResponse.Content;
            var bearer = restApi.RetrieveToken(tokenResponse);
            Console.WriteLine(bearer);
            return bearer;
        }

        public string getCompanyId()
        {
            var response = restApi.GetRequest(createToken());
            var content = response.Content;
            string companyID = restApi.RetrieveId(content);
            return companyID;
        }


        [TestMethod, Order(1)]
        public void CreateCompany()
        {
            var postCompanyResponse = restApi.PostRequest(createToken());
            var postCompanyContent = postCompanyResponse.Content;
            Console.WriteLine(postCompanyResponse.StatusCode.ToString());

        }

        [TestMethod, Order(2)]

        public void GetAllCompanies()
        {
            var allCompaniesResponse = restApi.GetRequest(createToken());
            var allCompaniesContent = allCompaniesResponse.Content;
            var compId = restApi.RetrieveId(allCompaniesContent);

            Console.WriteLine(allCompaniesResponse.StatusCode.ToString());
            Console.WriteLine(allCompaniesContent);
            
        }

        [TestMethod, Order(3)]

        public void GetCompanyById()
        {
            var getCompanyResponse = restApi.GetByIdRequest(createToken(), getCompanyId());
            var getCompanyContent = getCompanyResponse.Content;
            
            Console.WriteLine(getCompanyResponse.StatusCode.ToString());
            Console.WriteLine(getCompanyContent);

        }

        [TestMethod, Order(4)]
        public void DeleteCompany()
        {
            var deleteCompanyResponse = restApi.DeleteRequest(createToken(), getCompanyId());
            var deleteCompanyContent = deleteCompanyResponse.Content;
            Console.WriteLine(deleteCompanyResponse.StatusCode.ToString());

        }

    }
}
