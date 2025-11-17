using StudentManagement_MVC.Models.StuddentManagement_database;

namespace StudentManagement_MVC.Data.Service
{
    public class StudentService : ITF_Student
    {
        public Task AddStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public Task DeleteStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetAllStudents()
        {
            throw new NotImplementedException();
        }


        public Task ModifyStudent(Student student)
        {
            throw new NotImplementedException();
        }

        Task<Student?> ITF_Student.GetStudentbyID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
