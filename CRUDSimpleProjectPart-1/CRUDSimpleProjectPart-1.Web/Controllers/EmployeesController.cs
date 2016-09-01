using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDSimpleProjectPart_1.DAL;
using CRUDSimpleProjectPart_1.Model;
using CRUDSimpleProjectPart_1.Web.Models.ViewModel;

namespace CRUDSimpleProjectPart_1.Web.Controllers
{
    public class EmployeesController : Controller
    {

        private EmployeeInformationDbContext db=new EmployeeInformationDbContext();
        //
        // GET: /Employees/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllEmployee(EmployeeViewModel model)
        {
            model.Employees = db.Employees.OrderByDescending(x=>x.EmployeeID).ToList();

            var employees = model.Employees;


            

            return new JsonResult {Data = employees, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }
       
        public JsonResult Reload()
        {
            return Json(new { Success = true, Reload = true }, JsonRequestBehavior.AllowGet);
        }
        //public JsonResult Reload(int saveStatus)
        //{
        //    return saveStatus > 0 ? Json(new {Success = true, Reload = true}, JsonRequestBehavior.AllowGet):
        //}

        //public JsonResult Save(EmployeeViewModel model)
        //{
        //    int saveIndex = 0;
        //    if (model.Employee.EmployeeID>0)
        //    {
        //        db.Entry(model.Employee).State=EntityState.Modified;
        //         saveIndex = db.SaveChanges();
        //    }
        //    else
        //    {
        //        db.Employees.Add(model.Employee);
        //         saveIndex = db.SaveChanges();
        //    }

            
        //    return Reload();
        //}
        public ActionResult Save(EmployeeViewModel model)
        {
           
            if (model.Employee.EmployeeID > 0)
            {
                db.Entry(model.Employee).State = EntityState.Modified;
               db.SaveChanges();
            }
            else
            {
                db.Employees.Add(model.Employee);
               db.SaveChanges();
            }


            return View("Index");
        }

        public ActionResult Edit(int id)
        {
            Employee anEmployee = db.Employees.Find(id) ?? new Employee();

            EmployeeViewModel model=new EmployeeViewModel();

            model.Employee.EmployeeID = anEmployee.EmployeeID;
            model.Employee.Name = anEmployee.Name;
            model.Employee.City = anEmployee.City;
            model.Employee.Address = anEmployee.Address;
            return View("Index", model);
        }

        public ActionResult Delete(int id)
        {
            Employee employee = db.Employees.Find(id) ?? new Employee();

            if (employee.EmployeeID>0)
            {
                db.Entry(employee).State = EntityState.Deleted;
                db.SaveChanges();
            }

            return View("Index");
        }
	}
}