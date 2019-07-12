using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    class Employee : BaseRestApi
    {
        //Definition of Employee's Data
        public string employeePath = "/api/automation/employees";
        public string employeeIdPath = "/api/automation/employees/id/";
        public string employeeName = "TestEmployee" + GetRandomNumber();

    }
}
