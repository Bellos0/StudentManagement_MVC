using Microsoft.AspNetCore.Mvc;
using StudentManagement_MVC.Data.Service;
using StudentManagement_MVC.Models.StuddentManagement_database;
using System.Threading.Tasks;

namespace StudentManagement_MVC.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ITF_Subject _subjectService;
        public SubjectController(ITF_Subject subjectService)
        {
            _subjectService = subjectService;
        }
        public async Task<IActionResult> Index()
        {
            var subjectlist = await _subjectService.GetAllSubject();
            return View("~/Views/StudentManagementView/Subject/Index.cshtml", subjectlist);
        }

        /// <summary>
        /// method to delete subject by its id, nhung thuc te khong xoa duoc do dang co contraint la foreign key, chuc nang deleted bi ngan chan boi entity framework va sql server
        /// </summary>
        /// <param name="SubId"></param>
        /// <returns></returns>
        public async Task<IActionResult> DelSubByID(string SubId)
        {
            await _subjectService.DeleteSubject(SubId);
            return RedirectToAction("Index");

        }



        [HttpGet]
        public ActionResult AddSub()
        {
            
                return View("~/Views/StudentManagementView/Subject/AddSubject.cshtml", null);
           
        }




        [HttpPost]
        public async Task<IActionResult> AddSub(Subject? subject)
        {
            if (subject == null)
            {
                return View("~/Views/StudentManagementView/Subject/AddSubject.cshtml", null);
            }
            else
            {
                await _subjectService.AddSubject(subject);
                return RedirectToAction("Index");
            }
        }
    }
}
