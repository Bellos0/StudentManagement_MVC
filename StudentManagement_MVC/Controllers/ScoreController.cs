using Microsoft.AspNetCore.Mvc;

namespace StudentManagement_MVC.Controllers
{
    public class ScoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
