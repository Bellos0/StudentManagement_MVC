using Microsoft.AspNetCore.Mvc;

namespace StudentManagement_MVC.Controllers
{
    public class SubjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
