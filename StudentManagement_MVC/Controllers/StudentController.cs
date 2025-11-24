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

        [HttpPost]
        public async Task<IActionResult> Add(Student student)
        {
            if (ModelState.IsValid)
            {
                await _studentService.AddStudent(student);
                return RedirectToAction("Index");
            }
            return View("~/Views/StudentManagementView/Student/AddStudent.cshtml", student);
        }


        /// <summary>
        /// cai nay de tao tu dong ma hoc sinh, mai ve can chay kiem chung xem the nao
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GenStuID()
        {
            string strStuID;
            Random rnd = new Random();
            string _subStuID_datetime = DateTime.Now.ToString("yyyyMMdd");
            _subStuID_datetime = _subStuID_datetime.Remove(0, 2);
            strStuID = _subStuID_datetime + rnd.Next(0, 9999).ToString();
            var _existStudent = await _studentService.GetStudentbyID(strStuID);
            if (_existStudent == null)
            {
                _existStudent.StuId = strStuID;
            }
            return View("~/Views/StudentManagementView/Student/AddStudent.cshtml", _existStudent);

        }


        /// <summary>
        /// tim hoc sinh bang so id de dien vao form edit
        /// </summary>
        /// <param name="StuID"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> SearchStudentByID(string? StuID)
        {
            if (string.IsNullOrEmpty(StuID))
            {
                return RedirectToAction("~/Views/StudentManagementView/Student/EditStudent.cshtml");
            }
            var student = await _studentService.GetStudentbyID(StuID);
            if (student == null)
            {
                return View("~/Views/StudentManagementView/Student/EditStudent.cshtml", null);
            }
            else
            {
                return View("~/Views/StudentManagementView/Student/EditStudent.cshtml", student);
            }
        }



        [HttpPost]
        public async Task<IActionResult> EditInfo(Student model)
        {
            await _studentService.ModifyStudent(model);
            return View("~/Views/StudentManagementView/Student/Index.cshtml", model);
        }
    }
}
