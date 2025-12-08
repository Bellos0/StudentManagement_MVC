using Microsoft.EntityFrameworkCore;
using StudentManagement_MVC.Models.StuddentManagement_database;

namespace StudentManagement_MVC.Data.Service
{
    public class SubjectService : ITF_Subject
    {
        private readonly StudenManagementContext _context;
        public SubjectService(StudenManagementContext context)
        {
            _context = context;
        }
        public SubjectService()
        {
        }

        public async Task AddSubject(Subject subject)
        {
            //throw new NotImplementedException();
            if (subject != null)
            {
                _context.Subjects.Add(subject);
                await _context.SaveChangesAsync();

            }

        }


        public async Task DeleteSubject(string? subID)
        {
            //throw new NotImplementedException();
            var subjectInDb = await _context.Subjects.FirstOrDefaultAsync(s => s.SubId == subID);
            if (subjectInDb != null)
            {
                _context.Subjects.Remove(subjectInDb);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Subject>> GetAllSubject()
        {
            //throw new NotImplementedException();
            var subjectList = await _context.Subjects.ToListAsync();
            return subjectList;
        }

        public async Task ModifySubject(Subject subject)
        {
            //throw new NotImplementedException();
            var subjectInDb = await _context.Subjects.FirstOrDefaultAsync(s => s.SubId == subject.SubId);
            if (subjectInDb != null)
            {
                subjectInDb.Subname = subject.Subname;

                await _context.SaveChangesAsync();
                await _context.Entry(subjectInDb).ReloadAsync();
            }
        }
    }
}
