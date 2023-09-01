using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SingalPageCrud.Data;
using SingalPageCrud.Models;
using System.Linq;

namespace SingalPageCrud.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext db;
        public EmployeeController(AppDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
      
        public IActionResult GetEmployeeFormList()
        {
            ViewBag.DepartmentList = new SelectList(db.Departments.ToList(), "Did", "Name");
            return PartialView();
        }
        public JsonResult GetEmployeeList()
        {
            try
            {
                var list = from e in db.Employees.ToList()
                           join d in db.Departments.ToList() on e.Did equals d.Did
                           select new  { EmpId = e.EmpId,FirstName= e.FirstName,Department = d.Name,Email = e.Email,Address = e.Address };
                           
                    

                return Json(new JsonResponse() { IsSuccess = true,Data=list});
            }
            catch (System.Exception ex)
            {
                return Json(new JsonResponse() { IsSuccess = false, Message=ex.Message });
                throw;
            }
        }

        [HttpPost]
        public JsonResult CreateOrEdit(Employee model)
        {
            try
            {
                if (model.EmpId > 0)
                {
                    db.Employees.Add(model); db.SaveChanges();
                }
                else
                {
                    db.Employees.Update(model); db.SaveChanges();
                }
                return Json(new JsonResponse() {Message= "Success",Data= model });
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
