using Microsoft.EntityFrameworkCore;
using TraineeAPI.Data;
using TraineeAPI.Models;
using TraineeAPI.Repositories.Interfaces;

namespace TraineeAPI.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _context.Students
                .Include(s => s.User)
                .Include(s => s.Enrollments)
                .Include(s => s.Attendances)
                .ToListAsync();
        }

        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            return await _context.Students
                .Include(s => s.User)
                .Include(s => s.Enrollments)
                .Include(s => s.Attendances)
                .FirstOrDefaultAsync(s => s.StudentId == id);
        }

        public async Task<Student?> GetStudentByUserIdAsync(int userId)
        {
            return await _context.Students
                .Include(s => s.User)
                .Include(s => s.Enrollments)
                .Include(s => s.Attendances)
                .FirstOrDefaultAsync(s => s.UserId == userId);
        }

        public async Task<Student?> GetStudentByStudentCodeAsync(
            string studentCode)
        {
            return await _context.Students
                .Include(s => s.User)
                .Include(s => s.Enrollments)
                .Include(s => s.Attendances)
                .FirstOrDefaultAsync(
                    s => s.StudentCode == studentCode);
        }

        public async Task<Student> AddStudentAsync(Student student)
        {
            _context.Students.Add(student);

            await _context.SaveChangesAsync();

            return student;
        }

        public async Task<Student?> UpdateStudentAsync(Student student)
        {
            var existingStudent = await _context.Students
                .FindAsync(student.StudentId);

            if (existingStudent == null)
            {
                return null;
            }

            existingStudent.UserId = student.UserId;
            existingStudent.StudentCode = student.StudentCode;
            existingStudent.EnrollmentDate = student.EnrollmentDate;

            await _context.SaveChangesAsync();

            return existingStudent;
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var student = await _context.Students
                .FindAsync(id);

            if (student == null)
            {
                return false;
            }

            _context.Students.Remove(student);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}