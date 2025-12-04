using Microsoft.AspNetCore.Mvc;
using StudentManagement_MVC.Data.Service;
using StudentManagement_MVC.Models.StuddentManagement_database;

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
            var scorelist = await _scoreService.GetScoresDB(null);
            return View("~/Views/StudentManagementView/Score/Index.cshtml", scorelist);
        }

        [HttpGet]
        public IActionResult SearchScoreStudenContains(string? searchStr)
        {

            if (searchStr == null)
            {
                return View("~/Views/StudentManagementView/Score/Index.cshtml", null);
            }
            else
            {
                var scoreStudent = _scoreService.GetScoresbyContains(searchStr);
                return View("~/Views/StudentManagementView/Score/Index.cshtml", scoreStudent);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ModifiedScore(string stuID)
        {
            var scorestudent = await _scoreService.GetStuScoreByStuID(stuID);
            return View("~/Views/StudentManagementView/Score/EditScore.cshtml", scorestudent);
        }





        [HttpPost]
        public async Task<IActionResult> ModifiedScore(Score score)
        {
            if (ModelState.IsValid)
            {
                var newScore = await _scoreService.ModifyScore(score);
                


               var scorelist = await _scoreService.GetScoresDB(newScore);
                // gaisu tra ra index thi sao
                return View("~/Views/StudentManagementView/Score/Index.cshtml", scorelist);
                // return View("~/Views/StudentManagementView/Score/ShowResultByForeach.cshtml", scorelist);
                //var _score= _scoreService.GetScoresbyContains(score.StuId);
                // return View("~/Views/StudentManagementView/Score/ShowResultEdit.cshtml", _score);
            }
            return View("~/Views/StudentManagementView/Score/ShowResultEdit.cshtml", score);

        }




        [HttpGet]
        public async Task<IActionResult> ListShowForeach(Score score)
        {
            var scorelist = await _scoreService.GetScoresDB(score);
            return View("~/Views/StudentManagementView/Score/ShowResultByForeach.cshtml", score);
        }
    }
}
