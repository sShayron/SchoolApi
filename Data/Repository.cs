using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Models;

namespace SchoolApi.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        // STUDENT
        public async Task<Student[]> GetAllStudentsAsync(bool includeTeacher)
        {
            IQueryable<Student> query = _context.Students;

            if (includeTeacher)
            {
                query = query.Include(x => x.Teacher);
            }

            query = query.AsNoTracking().OrderBy(x => x.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Student[]> GetStudentAsyncByTeacherId(int TeacherId, bool includeTeacher = false)
        {
            IQueryable<Student> query = _context.Students;

            if (includeTeacher)
            {
                query = query.Include(x => x.Teacher);
            }

            query = query.AsNoTracking().Where(x => x.TeacherId == TeacherId);

            return await query.ToArrayAsync();
        }

        public async Task<Student> GetStudentAsyncById(int StudentId, bool includeTeacher = false)
        {
            IQueryable<Student> query = _context.Students;

            if (includeTeacher)
            {
                query = query.Include(x => x.Teacher);
            }

            query = query.AsNoTracking().Where(x => x.Id == StudentId);

            return await query.FirstOrDefaultAsync();
        }

        // TEACHER
        public async Task<Teacher[]> GetTeachersAsync(bool includeStudents = false)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeStudents)
            {
                query = query.Include(x => x.Students);
            }

            query = query.AsNoTracking().OrderBy(x => x.Id);

            return await query.ToArrayAsync();

        }

        public async Task<Teacher> GetTeacherAsyncById(int TeacherId, bool includeStudents = false)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeStudents)
            {
                query = query.Include(x => x.Students);
            }

            query = query.AsNoTracking().Where(x => x.Id == TeacherId);

            return await query.FirstOrDefaultAsync();
        }
    }
}