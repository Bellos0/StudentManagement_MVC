using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using StudentManagement_MVC.Data;
using StudentManagement_MVC.Data.Service;
using StudentManagement_MVC.Models;
using StudentManagement_MVC.Models.StuddentManagement_database;
using System.Text.RegularExpressions;

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

        [HttpGet]
        public ActionResult Add()
        {
            return View("~/Views/StudentManagementView/Student/AddStudent.cshtml");
        }



        [HttpPost]
        public async Task<IActionResult> Add(Student? student)
        {

            string strStuID;
            Random rnd = new Random();
            string _subStuID_datetime = DateTime.Now.ToString("yyyyMM").Remove(0, 2);
            strStuID = _subStuID_datetime + "-" + rnd.Next(0, 9999).ToString();
            var _existStudent = await _studentService.GetStudentbyID(strStuID);
            if (_existStudent == null && student != null)
            {
                student.StuId = strStuID;
                // vi model da duoc add thong qua doi so truyen vao, nen khi set lai gia tri cho no se bi loi validate.
                // de co the cap nhat lai gia tri ta buoc phai xoa StuId ban dau va set lai gia tri moi, khi ay se k bi loi validate nua
                ModelState.Remove("StuId");

            }

            if (student == null)
            {
                return View("~/Views/StudentManagementView/Student/AddStudent.cshtml");
            }



            if (ModelState.IsValid)
            {
                await _studentService.AddStudent(student);
                return RedirectToAction("Index", "Student");
            }
            return View("~/Views/StudentManagementView/Student/AddStudent.cshtml", student);
        }



        /// <summary>
        /// tim hoc sinh bang so id de dien vao form edit student
        /// </summary>
        /// <param name="StuID"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> SearchStudentByID(string? StuID)
        {
            if (string.IsNullOrEmpty(StuID))
            {
                return View("~/Views/StudentManagementView/Student/EditStudent.cshtml", null);
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


        /// <summary>
        /// sua thong tin student,
        /// chinh sua thong tin thong qua form edit student
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EditInfo(Student model)
        {
            await _studentService.ModifyStudent(model);
            return View("~/Views/StudentManagementView/Student/Index.cshtml", model);
        }



        /// <summary>
        /// get thong tin bang nut edit o index page.
        /// sau do fill vao trong form edit student by click
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]//("{id:int}")]
        public async Task<IActionResult> EditInfor(int id)
        {
            var student = await _studentService.GetStudentbyID(id);// tra ra model student
            //await _studentService.ModifyStudent(student);
            return View("~/Views/StudentManagementView/Student/EditStudentByClick.cshtml", student);
        }
        /// <summary>
        /// edit update info bang cach click edit o index page
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EditInfor(Student model)
        {
            if (ModelState.IsValid)
            {
                await _studentService.ModifyStudent(model);
                TryValidateModel(model);
                var _student = await _studentService.GetAllStudents();
                return View("~/Views/StudentManagementView/Student/Index.cshtml", _student);
            }
            else
            {
                //await _studentService.ModifyStudent(model);
                //TryValidateModel(model);
                return View("~/Views/StudentManagementView/Student/EditStudentByClick.cshtml", model);
            }

        }


        [HttpGet]
        public  IActionResult SearchByContains(string? strSearch)
        {

            
            if (strSearch != null)
            {
                var studentSeach = _studentService.GetAllStudentsByContaint(strSearch);
                return View("~/Views/StudentManagementView/Student/SearchAndResult.cshtml", studentSeach);
            }

            return View("~/Views/StudentManagementView/Student/SearchAndResult.cshtml");
        }
    }
}
