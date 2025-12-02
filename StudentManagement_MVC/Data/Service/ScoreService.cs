using Azure.Core;
using Microsoft.EntityFrameworkCore;
using StudentManagement_MVC.Models.StuddentManagement_database;
using System.Threading.Tasks;

namespace StudentManagement_MVC.Data.Service
{
    public class ScoreService : ITF_Score
    {
        private readonly StudenManagementContext _context;
        public ScoreService(StudenManagementContext context)
        {
            _context = context;
        }
        public async Task AddScore(Score score)
        {
            //throw new NotImplementedException();
            if (score != null)
            {
                _context.Scores.Add(score);
                await _context.SaveChangesAsync();
            }
        }


        public IEnumerable<Score> GetScoresbyContains(string? searchStr)
        {
            //throw new NotImplementedException();
            IQueryable<Score> query = _context.Scores;
            if (!string.IsNullOrEmpty(searchStr))
            {
                query = query.Where
                    (
                    s => s.StuId.ToString().Contains(searchStr)
                    || s.SubId.ToString().Contains(searchStr)
                    || s.Stuname!.Contains(searchStr)
                    || s.AvgScore.ToString().Contains(searchStr)
                    || s.Score15.ToString().Contains(searchStr)
                    || s.Score60.ToString().Contains(searchStr)
                    || s.AvgScore.ToString().Contains(searchStr)
                    );
            }
            return query.ToList();
        }

        public async Task<IEnumerable<Score>> GetScoresDB()
        {
            //throw new NotImplementedException();
            return await _context.Scores.ToListAsync();

        }

        public async Task ModifyScore(Score score)
        {
            //throw new NotImplementedException();

            var _scoreDB = await _context.Scores.FirstOrDefaultAsync(s => s.Id == score.Id);
            if (_scoreDB != null)
            {
                score.Stu = _scoreDB.Stu;
                score.Stuname = _scoreDB.Stuname;
                score.AvgScore = _scoreDB.AvgScore;
                score.Score15 = _scoreDB.Score15;
                score.Score60 = _scoreDB.Score60;
                score.Sub = _scoreDB.Sub;
                await _context.SaveChangesAsync();
            }

        }


    }
}
