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



        /// <summary>
        /// hien thi danh sach teacher user
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var teacherUserlist = await _Teacherlog.getAllTeacherlog();
            return View("~/Views/StudentManagementView/Teacherlog/Index.cshtml", teacherUserlist);

        }


        public async Task<IActionResult> Login(string? Uname, string? Pass)
        {
            if (string.IsNullOrEmpty(Uname) || string.IsNullOrEmpty(Pass))
            {
                return View("~/Views/StudentManagementView/Teacherlog/Login.cshtml");
            }

            var teacher = await _Teacherlog.GetTeacherByUname(Uname);
            if (teacher != null)
            {
                if (teacher.Pass == Pass)
                {
                    TempData["Message"] = "Login successful";
                    // i wanna save session here, i dont see session belongs to system.web here
                    HttpContext.Session.SetString("username",Uname);
                    return RedirectToAction("Index");
                }

            }
            else
            {
                TempData["Message"] = "Login failed";
            }
            return View("~/Views/StudentManagementView/Teacherlog/Login.cshtml");
        }




        /// <summary>
        /// HIen thi trang Register
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// input username de tim ra thong tin cua user
        /// </summary>
        /// <param name="Uname"></param>
        /// <returns></returns>
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
                return View("~/Views/StudentManagementView/Teacherlog/EditTeacherInfo.cshtml", null);
            }
            else
            {
                return View("~/Views/StudentManagementView/Teacherlog/EditTeacherInfo.cshtml", teacher);
            }
        }



        /// <summary>
        /// sua doi thong tin user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> UpdateTeacherInfo(Teacherlog model)
        {
            await _Teacherlog.UpdateTeacherInfo(model);
            return RedirectToAction("Index");
        }




    }
}
