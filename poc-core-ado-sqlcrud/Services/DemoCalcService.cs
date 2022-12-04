using System;
using System.Data;
using dotnet_ado_sql_poc.Models;

namespace dotnet_ado_sql_poc.Services
{
	public class DemoCalcService: IDemoCalc
	{
        public string getName()
        {
            string msg = "Logged in successfully";
            return msg;
        }

        public string getAdd(int num1, int num2)
        {
            int sum = 0;
            if (num1 >= 0 && num2 >= 0)
            {
                sum = (num1 + num2);
                return $"The sum is {sum}";
            }
            else
                return "Enter the proper inputs in query parameter";
        }

        public string getSub(int num1, int num2)
        {
            int sub = 0;
            if (num1 >= 0 && num2 >= 0)
            {
                sub = (num1 - num2);
                return $"The difference is {sub}";
            }
            else
                return "Enter the proper inputs in query parameter";
        }
   
        public string getProd(int num1, int num2)
        {
            int prod = 0;
            if (num1 >= 0 && num2 >= 0)
            {
                prod = (num1 * num2);
                return $"The product is {prod}";
            }
            else
                return "Enter the proper inputs in query parameter";
        }

        public string getDiv(int num1, int num2)
        {
            int div = 0;
            if (num1 >= 0 && num2 >= 0)
            {
                div = (num1 / num2);
                return $"The product is {div}";
            }
            else
                return "Enter the proper inputs in query parameter";
        }
    }    
	
}

