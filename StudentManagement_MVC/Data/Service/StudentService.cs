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
                studentInDb.StuId = student.StuId;
                studentInDb.Fullname = student.Fullname;
                studentInDb.DoB = student.DoB;
                studentInDb.Sex = student.Sex;
                studentInDb.Address = student.Address;
                studentInDb.ParentPhone = student.ParentPhone;
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
