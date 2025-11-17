using StudentManagement_MVC.Models.StuddentManagement_database;

namespace StudentManagement_MVC.Data.Service
{
    public interface ITF_Score
    {
        Task AddScore(Score score);
        Task ModifyScore(Score score);
        Task DeleteScore(Score score);
    }
}
