using StudentManagement_MVC.Models.StuddentManagement_database;

namespace StudentManagement_MVC.Data.Service
{
    public interface ITF_Student
    {
        Task<Student?> GetStudentbyID(string StuID);
        Task<Student?> GetStudentbyID(int id);
        Task AddStudent(Student student);
        Task ModifyStudent(Student student);
        //Task ModifyStudent(int id);
        Task DeleteStudent(Student student);
        Task<IEnumerable<Student>> GetAllStudents();
    }
}
