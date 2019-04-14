using System.Threading.Tasks;
using SchoolApi.Models;

namespace SchoolApi.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();
        // STUDENT
        Task<Student[]> GetAllStudentsAsync(bool includeTeacher);
        Task<Student[]> GetStudentAsyncByTeacherId(int TeacherId, bool includeTeacher);
        Task<Student> GetStudentAsyncById(int StudentId, bool includeTeacher);
        // TEACHER
        Task<Teacher[]> GetTeachersAsync(bool includeStudents);
        Task<Teacher> GetTeacherAsyncById(int TeacherId, bool includeStudents);
    }
}