using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCWebDemo.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVCWebDemo.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: /<controller>/
        EmployeeDataAccessLayer ObjEmployee = new EmployeeDataAccessLayer();
        public IActionResult Index()
        {
            List<Employee> lstEmployee = new List<Employee>();
            lstEmployee = ObjEmployee.GetAllEmployees().ToList();

            return View(lstEmployee);
            //return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Employee employee)
        {
            if (ModelState.IsValid)
            {
                ObjEmployee.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee employee = ObjEmployee.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind]Employee employee)
        {
            if (id != employee.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                ObjEmployee.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee employee = ObjEmployee.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee employee = ObjEmployee.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            ObjEmployee.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

    }
}
