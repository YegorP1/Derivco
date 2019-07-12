using Newtonsoft.Json.Linq;
using RestSharp;


namespace UnitTestProject1
{
    class Company : BaseRestApi
    {
        public string companyPath;
        public string companyIdPath;
        public string companyName;

        public Company()
        {
            //Definition of Company Data
            companyPath = "/api/automation/companies";
            companyIdPath = "/api/automation/companies/id/";
            companyName = "TestCompany" + GetRandomNumber();                   
        }
    }
}
