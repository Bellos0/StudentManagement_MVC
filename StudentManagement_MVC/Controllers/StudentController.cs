using Microsoft.AspNetCore.Mvc;

namespace StudentManagement_MVC.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
