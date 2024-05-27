using CRUD_MVC_STORED_PROCEDURE.Data;
using CRUD_MVC_STORED_PROCEDURE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_MVC_STORED_PROCEDURE.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;


        public EmployeeController()
        {
            _context = new ApplicationDbContext();
        
        }


        // GET: Employee
        public ActionResult Index()
        {
            var employee = _context.Employee.ToList();
            return View(employee);
        }


        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if(ModelState.IsValid)
            {

                _context.Employee.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }


            return View();
        }



        [HttpGet]
        public ActionResult Edit(int id)
        {
            var employee = _context.Employee.Find(id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if(ModelState.IsValid)
            {

                var employeeindb = _context.Employee.Find(employee.EmployeeID);

                employeeindb.EmployeeName = employee.EmployeeName;

                employeeindb.Designation = employee.Designation;
                employeeindb.Age = employee.Age;


                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }




        [HttpGet]
        public ActionResult Delete(int id)
        {
            var employee = _context.Employee.Find(id);
            return View(employee);
        }


        [HttpPost]
        public ActionResult Delete(Employee employee)
        {
            var employeeindb = _context.Employee.Find(employee.EmployeeID);
            _context.Employee.Remove(employeeindb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Details(int id)
        {
            var employee = _context.Employee.Find(id);
            return View(employee);
        }







    }
}