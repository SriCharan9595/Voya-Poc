using System;
using dotnet_ado_sql_poc.Models;

namespace dotnet_ado_sql_poc.Services
{
	public interface IEmployee
	{
        IEnumerable<Employee> getAllEmps();
        Employee getEmpByID(int EmpID);
        string createEmp(Employee employee);
        string updateEmp(int EmpID, Employee employee);
        string removeEmp(int EmpID);
    }
}

