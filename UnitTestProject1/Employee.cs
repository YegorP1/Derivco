using RestSharp;
restapi
using Newtonsoft.Json.Linq;

using System;

Company_Employee_REST

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
