using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using StudentManagement_MVC.Models.StuddentManagement_database;

namespace StudentManagement_MVC.Data.Service
{
    public class TeacherlogService : ITF_Teacherlog
    {
        private readonly StudenManagementContext _context;

        public TeacherlogService(StudenManagementContext context)
        {
            _context = context;
        }


        public async Task AddTeacher(Teacherlog teacherlog)
        {
            _context.Teacherlogs.Add(teacherlog);
            await _context.SaveChangesAsync();


            //throw new NotImplementedException();
        }

        public Task<Teacherlog?> DeleteTeacher(int id)
        {
            throw new NotImplementedException();
            //_context.Teacherlogs.ExecuteDeleteAsync<Teacherlog>()
        }

        public async Task<IEnumerable<Teacherlog>> getAllTeacherlog()
        {
            var teacherlist = await _context.Teacherlogs.ToListAsync();
            return teacherlist;
        }



        /// <summary>
        /// su dung cai getteachbyUname de kiem tra dang nhap
        /// uname match, next den check pass match
        /// </summary>
        /// <param name="uname"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Teacherlog?> GetTeacherByUname(string uname)
        {
            //throw new NotImplementedException();
            return await _context.Teacherlogs.FirstOrDefaultAsync(t => t.Uname == uname);

        }

        public async Task UpdateTeacherInfo(Teacherlog model)
        {
            //throw new NotImplementedException();
            var newTeacher = await _context.Teacherlogs.FirstOrDefaultAsync(t => t.Uname == model.Uname);
            if (newTeacher != null)
            {
                newTeacher.Uname = model.Uname;
                newTeacher.Pass = model.Pass;
                newTeacher.Email = model.Email;
                newTeacher.Phone = model.Phone;
                await _context.SaveChangesAsync();
            }
            

        }
    }
}
