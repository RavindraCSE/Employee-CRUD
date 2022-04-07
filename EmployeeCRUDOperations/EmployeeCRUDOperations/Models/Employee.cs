using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeCRUDOperations.Models
{
    public class Employee
    {
        [Required(ErrorMessage ="Enter ID")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        public string  Name { get; set; }

        [Required(ErrorMessage = "Enter Location")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Enter Salary")]
        public int Salary { get; set; }

        [Required(ErrorMessage = "Enter DeptId")]
        public int DeptId { get; set; }
    }
}