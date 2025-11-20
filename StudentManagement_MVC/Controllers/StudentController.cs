using Microsoft.AspNetCore.Mvc;
using StudentManagement_MVC.Data;
using StudentManagement_MVC.Data.Service;
using StudentManagement_MVC.Models.StuddentManagement_database;

namespace StudentManagement_MVC.Controllers
{
    public class StudentController : Controller
    {

        private readonly ITF_Student _studentService;
        public StudentController(ITF_Student studentService)
        {
            _studentService = studentService;
        }
        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetAllStudents();

            return View("~/Views/StudentManagementView/Student/Index.cshtml", students);
        }
    }
}
