using RestSharp;
using Newtonsoft.Json.Linq;

namespace UnitTestProject1
{
    class Employee : BaseRestApi
    {
        //Definition of Employee Data
        public string employeePath = "/api/automation/employees";
        public string employeeIdPath = "/api/automation/employees/id/";
        public string employeeName = "TestEmployee" + GetRandomNumber();

    }
}
