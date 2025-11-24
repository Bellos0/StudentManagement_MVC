using Microsoft.AspNetCore.Mvc;
using StudentManagement_MVC.Data.Service;

namespace StudentManagement_MVC.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ITF_Subject _subjectService;
        public SubjectController(ITF_Subject subjectService)
        {
            _subjectService = subjectService;
        }
        public IActionResult Index()
        {
            return View("~/Views/StudentManagementView/Subject/Index.cshtml");
        }

        [HttpPost]

    }
}
