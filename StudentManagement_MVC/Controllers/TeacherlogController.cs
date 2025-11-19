using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
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
            var teacherUserlist = await _Teacherlog.getAllTeacherlog();
            return View("~/Views/StudentManagementView/Teacherlog/Index.cshtml", teacherUserlist);

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

        
        [HttpGet]
        public async Task<IActionResult> FindTeacherByUname(string? Uname)
        {
            if (string.IsNullOrEmpty(Uname))
            {
                return View("~/Views/StudentManagementView/Teacherlog/EditTeacherInfo.cshtml");
            }
            var teacher = await _Teacherlog.GetTeacherByUname(Uname);
            if (teacher == null)
            {
                ViewBag.Error = "teacher not found";
                return View("~/Views/StudentManagementView/Teacherlog/EditTeacherInfo.cshtml",null);
            }
            else
            {
                return View("~/Views/StudentManagementView/Teacherlog/EditTeacherInfo.cshtml", teacher);
            }
        }

        [HttpPost]
        public async Task<ActionResult> UpdateTeacherInfo(Teacherlog model)
        {
            await _Teacherlog.UpdateTeacherInfo(model);
            return RedirectToAction("Index");
        }

    }
}
