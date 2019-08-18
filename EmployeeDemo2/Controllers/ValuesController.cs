using EmployeeDemo2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;  
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Web.Http.Cors;

namespace EmployeeDemo2.Controllers
{
    [EnableCors(origins: "http://localhost:7772", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        // GET api/values
        public EmployeeResponse Get()
        {
            List<Employee> employees = new List<Employee>();
            ErrorResponseModel errorResponse = new ErrorResponseModel();
            EmployeeResponse employeeResponse = new EmployeeResponse();
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(HttpContext.Current.Server.MapPath("../Employees.xml"));
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Employee employee = new Employee();
                    employee.ID = Convert.ToInt16(dr["id"]);
                    employee.Name = dr["name"].ToString();
                    employee.Department = dr["department"].ToString();
                    employee.Location = dr["location"].ToString();

                    employees.Add(employee);
                }
                errorResponse.StatusCode = 0;
                errorResponse.ErrorMessage = "";
                employeeResponse.Response = employees;
                employeeResponse.ErrorResponse = errorResponse;
                return employeeResponse;
            }
            catch(Exception)
            {
                errorResponse.StatusCode = 500; 
                errorResponse.ErrorMessage = "Server Error";
                employeeResponse.Response = employees;
                employeeResponse.ErrorResponse = errorResponse;
                return employeeResponse;
            }
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
