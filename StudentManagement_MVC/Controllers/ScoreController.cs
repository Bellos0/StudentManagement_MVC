using Microsoft.AspNetCore.Mvc;
using StudentManagement_MVC.Data.Service;

namespace StudentManagement_MVC.Controllers
{
    public class ScoreController : Controller
    {
        private readonly ITF_Score _scoreService;
        public ScoreController(ITF_Score scoreservice)
        {
            _scoreService = scoreservice;
        }
        public async Task<IActionResult> Index()
        {
          var scorelist= _scoreService.GetScoresDB();
            return View("~/Views/StudentManagementView/Score/Index.cshtml", scorelist);
        }

        [HttpGet]
        public async Task<IActionResult> SearchScoreStudenContains(string? searchStr)
        {

            if (searchStr == null)
            {
                return View("~/Views/StudentManagementView/Score/Index.cshtml",null);
            }
            else
            {
                var scoreStudent =    _scoreService.GetScoresbyContains(searchStr);
                return View("~/Views/StudentManagementView/Score/Index.cshtml", scoreStudent);
            }
        }
    }
}
