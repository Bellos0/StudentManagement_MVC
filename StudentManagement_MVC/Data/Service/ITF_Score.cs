using StudentManagement_MVC.Models.StuddentManagement_database;

namespace StudentManagement_MVC.Data.Service
{
    public interface ITF_Score
    {
        Task AddScore(Score score);
        Task ModifyScore(Score score);
        Task<IEnumerable<Score>> GetScoresDB();
        Task<Score?> GetDataByStuID(string stuID);
        Task<Score> GetStuScoreByStuID(string StuID);
        IEnumerable<Score> GetScoresbyContains(string? searchStr);
    }
}
