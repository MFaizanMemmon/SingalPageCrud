using Microsoft.AspNetCore.Mvc;
using SingalPageCrud.Data;
using SingalPageCrud.Models;
using System.Linq;

namespace SingalPageCrud.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly AppDbContext db;
        public DepartmentController(AppDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetDepartmentFormList()
        {
         
            return PartialView();
        }

        [HttpGet]
        public IActionResult GetDepartmentList() 
        {
            try
            {
                return Json(new JsonResponse() { IsSuccess = true, Data = db.Departments.ToList() });

            }
            catch (System.Exception ex)
            {

                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return Json(new JsonResponse() { IsSuccess = false,Message=msg });
            }
            
        }

        [HttpPost]
        public IActionResult InsertDepartment(Department model)
        {
            try
            {
                if (model.Did > 0)
                {
                    db.Departments.Update(model);
                    db.SaveChanges();
                    return Json(new JsonResponse() { IsSuccess = true, Message = "Record Updated Successfully", Data = model });
                }
                else
                {
                    db.Departments.Add(model);
                    db.SaveChanges();
                    return Json(new JsonResponse() { IsSuccess = true, Message = "Record Saved Successfully", Data = model });
                }
                
            }
            catch (System.Exception ex)
            {
                var msg = ex.Message != null ? ex.InnerException.Message : ex.Message;

                return Json(new JsonResponse() { IsSuccess = false, Message = msg });
            }
        }

        [HttpGet]
        public IActionResult GetDepartmentById(int id)
        {
            try
            {
                var obj = db.Departments.Find(id);
                return Json(new JsonResponse() { IsSuccess = true, Data = obj });
            }
            catch (System.Exception ex)
            {
                var msg = ex.Message != null ? ex.InnerException.Message : ex.Message;
                return Json(new JsonResponse() { IsSuccess = false, Message = msg });
            }
        }


    }
}
