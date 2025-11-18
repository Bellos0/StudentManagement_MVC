using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StudentManagement_MVC.Data.Service;
using StudentManagement_MVC.Models.StuddentManagement_database;

namespace StudentManagement_MVC.Controllers
{
    /// <summary>
    /// class nay xu ly bai toan dang nhap
    /// </summary>


    public class TeacherlogController : Controller
    {
        private readonly ITF_Teacherlog _Teacherlog;
        public TeacherlogController(ITF_Teacherlog Teacherlog)
        {
            _Teacherlog = Teacherlog;
        }

        public async Task<IActionResult> Index()
        {
           await _Teacherlog.getAllTeacherlog();
            return View("~/Views/StudentManagementView/Teacherlog/Index.cshtml");
            //var teacherlog = await _Teacherlog.getAllTeacherlog();
            //return View(teacherlog);
        }

        public IActionResult Register()
        {
            return View("~/Views/StudentManagementView/Teacherlog/Register.cshtml");
        }

        /// <summary>
        /// Register teacher user for login system
        /// </summary>
        /// <param name="teacherlog"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Register(Teacherlog teacherlog)
        {
            if (ModelState.IsValid)
            {
                await _Teacherlog.AddTeacher(teacherlog);
                TempData["Message"] = "operated success";
                return View("~/Views/StudentManagementView/Teacherlog/Index.cshtml");
            }
            else
            {
                TempData["Message"] = "operated False";
                return RedirectToAction("~/Views/StudentManagementView/Teacherlog/Register.cshtml");
            }
        }

    }
}
