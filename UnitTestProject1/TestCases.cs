using System;
using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
 
    public class TestCases
    {
        BaseRestApi restApi = new BaseRestApi();
        
        Company comp = new Company();

        Employee empl = new Employee();

        public string createToken()
        {
            var tokenResponse = restApi.GenerateToken();
            var tokenContent = tokenResponse.Content;
            var bearer = restApi.RetrieveToken(tokenResponse);
            //validate that token was created and retrieved successfully
            Console.WriteLine(bearer);
            return bearer;
        }

        public string getCompanyId()
        {
            var response = restApi.GetAll(createToken(), comp.companyPath);
            var content = response.Content;
            string companyId = restApi.RetrieveId(content);
            return companyId;
        }

        //public string getEmployeeId()
        //{
        //    var response = restApi.GetRequest(createToken(), empl.baseUrl, empl.employeePath);
        //    var content = response.Content;
        //    string companyId = restApi.RetrieveId(content);
        //    return companyId;
        //}


        [TestMethod, Order(1)]
        public void CreateCompany()
        {
            var companyResponse = comp.PostCompany();
            var companyContent = companyResponse.Content;
            //Assert Response Status Code
            restApi.AssertStatusCode(companyResponse);
        }

        [TestMethod, Order(2)]

        public void GetAllCompanies()
        {
            var allCompaniesResponse = comp.GetCompanies();
            var allCompaniesContent = allCompaniesResponse.Content;
            var compId = comp.RetrieveId(allCompaniesContent);
            //Validate the Response body content
            Console.WriteLine(allCompaniesContent);
            //Assert Response Status Code
            restApi.AssertStatusCode(allCompaniesResponse);
        }

        //[TestMethod, Order(3)]

        //public void GetSpecificCompanyById()
        //{
        //    var getCompanyResponse = comp.GetCompanyById();
        //    var getCompanyContent = getCompanyResponse.Content;
        //    //Validate the Response body content
        //    Console.WriteLine(getCompanyContent);
        //    //Assert Response Status Code
        //    restApi.AssertStatusCode(getCompanyResponse);

        //}

        [TestMethod, Order(3)]

        public void NewGetSpecificCompanyById()
        {
            var getCompanyResponse = restApi.GetById(createToken(), comp.companyPath, getCompanyId());
            var getCompanyContent = getCompanyResponse.Content;
            //Validate the Response body content
            Console.WriteLine(getCompanyContent);
            //Assert Response Status Code
            restApi.AssertStatusCode(getCompanyResponse);

        }

        //[TestMethod, Order(4)]
        //public void DeleteCompany()
        //{
        //    var deleteCompanyResponse = comp.Delete(getCompanyId());
        //    var deleteCompanyContent = deleteCompanyResponse.Content;

        //    //Assert Response Status Code
        //    restApi.AssertStatusCode(deleteCompanyResponse);
        //}

        //[TestMethod, Order(5)]
        //public void CreateEmployee()
        //{
        //    var postEmployeeResponse = restApi.PostRequest(createToken(), empl.baseUrl, empl.employeePath, empl.employeeName);
        //    var postEmployeeContent = postEmployeeResponse.Content;
        //    //Assert Response Status Code
        //    restApi.AssertStatusCode(postEmployeeResponse);
        //}

        //[TestMethod, Order(6)]

        //public void GetAllEmployees()
        //{
        //    var allEmployeesResponse = restApi.GetRequest(createToken(), empl.baseUrl, empl.employeePath);
        //    var allEmployeesContent = allEmployeesResponse.Content;
        //    var compId = restApi.RetrieveId(allEmployeesContent);

        //    Console.WriteLine(allEmployeesContent);
        //    //Assert Response Status Code
        //    restApi.AssertStatusCode(allEmployeesResponse);
        //}

        //[TestMethod, Order(7)]

        //public void GetEmployeeById()
        //{
        //    var getEmployeeResponse = restApi.GetById(empl.GenerateToken(), empl.employeeIdPath, getEmployeeId())
        //    var getEmployeeContent = getEmployeeResponse.Content;

        //    Console.WriteLine(getEmployeeContent);
        //    //Assert Response Status Code
        //    restApi.AssertStatusCode(getEmployeeResponse);
        //}

        //[TestMethod, Order(8)]
        //public void DeleteEmployee()
        //{
        //    var deleteEmployeeResponse = restApi.DeleteRequest(createToken(), empl.baseUrl, empl.employeeIdPath, getEmployeeId());
        //    var deleteEmployeeContent = deleteEmployeeResponse.Content;

        //    //Assert Response Status Code
        //    restApi.AssertStatusCode(deleteEmployeeResponse);
        //}


    }
}
