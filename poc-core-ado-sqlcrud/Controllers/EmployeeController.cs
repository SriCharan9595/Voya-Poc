using dotnet_ado_sql_poc.Models;
using dotnet_ado_sql_poc.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text.Json.Serialization;

namespace dotnet_ado_sql_poc.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployee _empServ;

        public EmployeeController(IEmployee empServ)
        {
            _empServ = empServ;
        }

        // GET: api/getAllEmps
        [HttpGet]
        public IEnumerable<Employee> getAllEmps()
        {
            var result = _empServ.getAllEmps();
            return result;
        }


        // GET api/getEmpByID/5
        [HttpGet("{EmpID}")]
        public Employee getEmpByID(int EmpID)
        {
            var result = _empServ.getEmpByID(EmpID);
            return result;
        }


        // POST api/createEmp
        [HttpPost]
        public string createEmp(Employee employee)
        {
            var result = _empServ.createEmp(employee);
            return result;
        }


        // PUT api/updateEmp/5
        [HttpPut("{EmpID}")]
        public string updateEmp(int EmpID, Employee employee)
        {
            var result = _empServ.updateEmp(EmpID, employee);
            return result;
        }


        // DELETE api/removeEmp/5
        [HttpDelete("{EmpID}")]
        public string removeEmp(int EmpID)
        {
            var result = _empServ.removeEmp(EmpID);
            return result;
        }
    }
}
