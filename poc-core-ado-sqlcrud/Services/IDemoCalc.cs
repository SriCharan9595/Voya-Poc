using System;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_ado_sql_poc.Services
{
	public interface IDemoCalc
	{
        string getName();
        string getAdd(int num1, int num2);
        string getSub(int num1, int num2);
        string getProd(int num1, int num2);
        string getDiv(int num1, int num2);
    }
}

