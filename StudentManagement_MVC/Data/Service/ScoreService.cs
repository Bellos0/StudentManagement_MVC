using Azure.Core;
using Microsoft.EntityFrameworkCore;
using StudentManagement_MVC.Models.StuddentManagement_database;
using System.Collections.Generic;
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
                    s => s.StuId!.ToString().Contains(searchStr)
                    || s.Stuname!.ToString().Contains(searchStr)
                    || s.AvgScore!.ToString().Contains(searchStr)
                    || s.Score15!.ToString().Contains(searchStr)
                    || s.Score60!.ToString().Contains(searchStr)
                    || s.AvgScore!.ToString().Contains(searchStr)
                    );
            }
            return query.ToList();
        }

        public async Task<IEnumerable<Score>> GetScoresDB()
        {
            //throw new NotImplementedException();
            return await _context.Scores.ToListAsync();

        }

        public async Task<Score> GetStuScoreByStuID(string StuID)
        {
            //throw new NotImplementedException();
            var _score = await _context.Scores.FirstOrDefaultAsync(s => s.StuId == StuID);
            return _score;
        }

        public async Task<Score?> ModifyScore(Score score)
        {
            //throw new NotImplementedException();

            var _scoreDB = await _context.Scores.FirstOrDefaultAsync(s => s.StuId == score.StuId);
            if (_scoreDB != null)
            {

                _scoreDB.Score15 = score.Score15;
                _scoreDB.Score60 = score.Score60;

                await _context.SaveChangesAsync();
                await _context.Entry(_scoreDB).ReloadAsync();
                //var scoreUpdated = await _context.Scores.FirstOrDefaultAsync(s => s.StuId == _scoreDB.StuId);
                var scoreUpdated = await _context.Scores.FindAsync(_scoreDB.Id);
                return scoreUpdated;
            }
            else
            {
                return null;
            }

        }

        public async Task<Score?> GetDataByStuID(string stuID)
        {
            // throw new NotImplementedException();
            return await _context.Scores.FirstOrDefaultAsync(s => s.StuId == stuID);
        }

        public async Task<IEnumerable<Score>> GetScoresDB(Score? score)
        {
            //throw new NotImplementedException();
            if (score == null)
            {
                var scoreDB = await _context.Scores.ToListAsync();
                return scoreDB;
            }
            else
            {
                var _scoreDB = await _context.Scores.FirstOrDefaultAsync(s => s.StuId == score.StuId);
                return _scoreDB != null ? new List<Score> { _scoreDB } : new List<Score>();

            }
        }


    }
}
