using StudentManagement_MVC.Models.StuddentManagement_database;

namespace StudentManagement_MVC.Data.Service
{
    public interface ITF_Score
    {
        Task AddScore(Score score);
        Task<Score?> ModifyScore(Score score);
        Task<IEnumerable<Score>> GetScoresDB(Score? score);
        Task<IEnumerable<Subject>> GetSubjectDB(); //load suject id, name tu table trong database
        Task<Score?> GetDataByStuID(string stuID);
        Task<Score> GetStuScoreByStuID(string StuID);
        IEnumerable<Score> GetScoresbyContains(string? searchStr);
    }
}
