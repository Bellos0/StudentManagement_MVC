using StudentManagement_MVC.Models.StuddentManagement_database;

namespace StudentManagement_MVC.Data.Service
{
    public interface ITF_Teacherlog

    {
        Task AddTeacher(Teacherlog teacherlog);
        Task<Teacherlog?> DeleteTeacher(int id);

        Task<Teacherlog?> GetTeacherByUname(string uname);
        Task<IEnumerable<Teacherlog>> getAllTeacherlog();
    }
}
