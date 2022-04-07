using EmployeeCRUDOperations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeCRUDOperations.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            EmployeeRepository employeeRepository = new EmployeeRepository();
            var emp = employeeRepository.GetEmployees();
            return View(emp);
        }


        public ActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeRepository employeeRepository = new EmployeeRepository();
                bool SucessVal = employeeRepository.AddEmployee(employee);
                if (SucessVal)
                {
                    TempData["SuccessMessage"] = "Employee Created sucessfully";
                    return RedirectToAction("Index");
                }

              
            }
            return View();


        }

      
      
        public ActionResult DeleteEmployee( int ID)
        {
            if(ModelState.IsValid)
            {

            EmployeeRepository employeeRepository = new EmployeeRepository();
            bool Sucsess = employeeRepository.DeleteEmp(ID);
            if(Sucsess)
                {
                    TempData["SuccessMessage"] = "Employee Deleted sucessfully";
                    return RedirectToAction("Index");
                }
            }
            return View();
        }


        public ActionResult EditEmployee(int ID)
        {
            EmployeeRepository employeeRepository = new EmployeeRepository();
            var employee = employeeRepository.GetEmployeesById(ID);
             return View(employee);


        }

        [HttpPost]
        public ActionResult EditEmployee(Employee employee)
        {
            if(ModelState.IsValid)
            {
                EmployeeRepository employeeRepository = new EmployeeRepository();
                bool SucessVal = employeeRepository.EditEmployee(employee);
                if (SucessVal)
                {
                    TempData["SuccessMessage"] = "Employee details updated sucessfully...";
                    return RedirectToAction("Index");
                }

            }
            return View();
        }

    }
}