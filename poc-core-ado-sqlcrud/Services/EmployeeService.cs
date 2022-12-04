using System;
using System.Data;
using dotnet_ado_sql_poc.Models;
using Microsoft.Data.SqlClient;
namespace dotnet_ado_sql_poc.Services
{
	public class EmployeeService: IEmployee
	{
        private readonly IConfiguration _config;
        private SqlConnection conn;

        public EmployeeService(IConfiguration config)
        {
            _config = config;
            string sqlConnStr = _config["sqlConn"];
            conn = new SqlConnection(sqlConnStr);
        }


        public IEnumerable<Employee> getAllEmps()
        {
            SqlDataAdapter sqlDA = new SqlDataAdapter("usp_GetAllEmps", conn);
            sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable dataTbl = new DataTable();
            sqlDA.Fill(dataTbl);
            List<Employee> empList = new List<Employee>();
            if (dataTbl.Rows.Count > 0)
            {
                for (int i = 0; i < dataTbl.Rows.Count; i++)
                {
                    Employee emp = new Employee();
                    emp.EmpID = Convert.ToInt32(dataTbl.Rows[i]["EmpID"]);
                    emp.EmpName = dataTbl.Rows[i]["EmpName"].ToString();
                    emp.EmpLocation = dataTbl.Rows[i]["EmpLocation"].ToString();
                    empList.Add(emp);
                }
            }
            if (empList.Count > 0)
                return empList;
            else
                return null;
        }


        public Employee getEmpByID(int EmpID)
        {
            SqlDataAdapter sqlDA = new SqlDataAdapter("usp_GetEmpByID", conn);
            sqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDA.SelectCommand.Parameters.AddWithValue("@EmpID", EmpID);

            DataTable dataTbl = new DataTable();
            sqlDA.Fill(dataTbl);

            Employee emp = new Employee();
            emp.EmpID = Convert.ToInt32(dataTbl.Rows[0]["EmpID"]);
            emp.EmpName = dataTbl.Rows[0]["EmpName"].ToString();
            emp.EmpLocation = dataTbl.Rows[0]["EmpLocation"].ToString();

            if (emp != null)
                return emp;
            else
                return null;
        }


        public string createEmp(Employee employee)
        {
            string msg = "";
            SqlCommand cmd = new SqlCommand("usp_AddEmp", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpName", employee.EmpName);
            cmd.Parameters.AddWithValue("@EmpLocation", employee.EmpLocation);

            conn.Open();
            int i = cmd.ExecuteNonQuery();
            conn.Close();

            if (i > 0)
                return msg = "Data has been inserted";
            else
                return msg = "Error";
        }


        public string updateEmp(int EmpID, Employee employee)
        {
            string msg = "";
            SqlCommand cmd = new SqlCommand("usp_UpdateEmp", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EmpID", EmpID);
            cmd.Parameters.AddWithValue("@EmpName", employee.EmpName);
            cmd.Parameters.AddWithValue("@EmpLocation", employee.EmpLocation);

            conn.Open();
            int i = cmd.ExecuteNonQuery();
            conn.Close();

            if (i > 0)
                return msg = "Data has been updated";
            else
                return msg = "Error";
        }


        public string removeEmp(int EmpID)
        {
            string msg = "";
            SqlCommand cmd = new SqlCommand("usp_DeleteEmp", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EmpID", EmpID);

            conn.Open();
            int i = cmd.ExecuteNonQuery();
            conn.Close();

            if (i > 0)
                return msg = "Data has been deleted";
            else
                return msg = "Error";
        }
    }
}