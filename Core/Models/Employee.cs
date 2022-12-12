using System;
using System.ComponentModel.DataAnnotations;

namespace AzureFuncApi.Core.Models
{
    public class Employee
    {
        [Display(Name = "Employee ID")]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "Name is mandatory")]
        public string Name { get; set; }

        public int Age { get; set; }

        public string Location { get; set; }

    }
}

