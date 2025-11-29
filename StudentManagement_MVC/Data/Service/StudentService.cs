using Microsoft.EntityFrameworkCore;
using StudentManagement_MVC.Models.StuddentManagement_database;

namespace StudentManagement_MVC.Data.Service
{
    public class StudentService : ITF_Student
    {
        private readonly StudenManagementContext _context;
        public StudentService(StudenManagementContext context)
        {
            _context = context;
        }
        public async Task AddStudent(Student student)
        {
            //throw new NotImplementedException();
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            
        }

        public async Task DeleteStudent(Student student)
        {
            //throw new NotImplementedException();
            var studentInDb = await _context.Students.FirstOrDefaultAsync(s => s.StuId == student.StuId);
            if (studentInDb != null)
            {
                _context.Students.Remove(studentInDb);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            //throw new NotImplementedException();
            return await _context.Students.ToListAsync();
        }


        public async Task ModifyStudent(Student student)
        {
            //throw new NotImplementedException();
            var studentInDb = await _context.Students.FirstOrDefaultAsync(s => s.Id == student.Id);
            if (studentInDb != null)
            {
                studentInDb.StuId = student.StuId.TrimStart().TrimEnd();
                studentInDb.Fullname = student.Fullname.TrimStart().TrimEnd();
                studentInDb.DoB = student.DoB;
                studentInDb.Sex = student.Sex.TrimStart().TrimEnd();
                studentInDb.Address = student.Address.TrimStart().TrimEnd();
                studentInDb.ParentPhone = student.ParentPhone.TrimStart().TrimEnd();
                await _context.SaveChangesAsync();

            }
        }

      

        public Task<Student?> GetStudentbyID(string StuID)
        {
            //throw new NotImplementedException();
            return _context.Students.FirstOrDefaultAsync(s=>s.StuId == StuID);
        }
    }
}
