using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using StudentManagement_MVC.Models.StuddentManagement_database;

namespace StudentManagement_MVC.Data.Service
{
    public interface ITF_Subject
    {
        Task<IEnumerable<Subject>> GetAllSubject();
        Task DeleteSubject(Subject subject);
        Task AddSubject(Subject subject);
        Task ModifySubject(Subject subject);
    }
}
