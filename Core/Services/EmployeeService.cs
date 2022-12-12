using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using AzureFuncApi.Core.Services;
using AzureFuncApi.Core.Models;

namespace AzureFuncApi.Core.Services
{
    public class EmployeeService: IEmployee
    {
        public static List<Employee> empList = null;

        public EmployeeService()
        {
            empList = new List<Employee>() {
                new Employee()
                {
                    EmployeeID = 1516,
                    Name = "Sricharan",
                    Age = 22,
                    Location = "Chennai",
                }
            };
        }

        public string getLogIn(string empName)
        {
            return $"{empName} logged in successfully";
        }

        public async Task <IEnumerable<Employee>> getAllEmployees()
        {
                return empList;     
        }

        public Employee getEmployeeByID(int empID)
        {
            Employee emp = empList.Find(x => x.EmployeeID == empID);
            if (emp == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return emp;
        }

        public string createEmployee(Employee emp)
        {
            if(emp != null)
            {
                empList.Add(emp);
                return "Employee created successfully";
            }
            else
                throw new HttpResponseException(HttpStatusCode.NotFound);

        }

        public string updateEmployee(Employee emp)
        {
            Employee empUpdate = empList.Find(x => x.EmployeeID == emp.EmployeeID);
            if (empUpdate != null)
            {
                empUpdate.Name = emp.Name;
                empUpdate.Age = emp.Age;
                empUpdate.Location = emp.Location;
                return "Employee updated successfully";
            }
            else
                throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        public string removeEmployee(int empID)
        {
            Employee empDelete = empList.Find(x => x.EmployeeID == empID);
            if (empDelete != null)
            {
                empList.Remove(empDelete);
                return "Employee removed successfully";
            }
            else
                throw new HttpResponseException(HttpStatusCode.NotFound);
        }
    }
}

