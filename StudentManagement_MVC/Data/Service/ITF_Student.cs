using StudentManagement_MVC.Models.StuddentManagement_database;

namespace StudentManagement_MVC.Data.Service
{
    public interface ITF_Student
    {
        Task<Student?> GetStudentbyID(string StuID);
        Task AddStudent(Student student);
        Task ModifyStudent(Student student);
        Task DeleteStudent(Student student);
        Task<IEnumerable<Student>> GetAllStudents();
    }
}
