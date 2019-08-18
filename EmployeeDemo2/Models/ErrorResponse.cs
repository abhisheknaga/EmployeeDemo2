using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeDemo2.Models
{

    public class EmployeeResponse
    {
        public List<Employee> Response { get; set; }
        public ErrorResponseModel ErrorResponse { get; set; }
    }

    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }
    }

    public class ErrorResponseModel
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}