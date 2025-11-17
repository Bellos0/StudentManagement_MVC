using Microsoft.AspNetCore.Mvc;

namespace StudentManagement_MVC.Controllers
{
    public class TeacherlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
