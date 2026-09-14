using Microsoft.EntityFrameworkCore;
using TraineeAPI.Data;
using TraineeAPI.Models;
using TraineeAPI.Repositories.Interfaces;

namespace TraineeAPI.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDbContext _context;

        public TeacherRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Teacher>> GetAllTeachersAsync()
        {
            return await _context.Teachers
                .Include(t => t.User)
                .Include(t => t.Courses)
                .ToListAsync();
        }

        public async Task<Teacher?> GetTeacherByIdAsync(int id)
        {
            return await _context.Teachers
                .Include(t => t.User)
                .Include(t => t.Courses)
                .FirstOrDefaultAsync(t => t.TeacherId == id);
        }

        public async Task<Teacher?> GetTeacherByUserIdAsync(int userId)
        {
            return await _context.Teachers
                .Include(t => t.User)
                .Include(t => t.Courses)
                .FirstOrDefaultAsync(t => t.UserId == userId);
        }

        public async Task<Teacher?> GetTeacherByEmployeeCodeAsync(
            string employeeCode)
        {
            return await _context.Teachers
                .Include(t => t.User)
                .Include(t => t.Courses)
                .FirstOrDefaultAsync(
                    t => t.EmployeeCode == employeeCode);
        }

        public async Task<Teacher> AddTeacherAsync(Teacher teacher)
        {
            _context.Teachers.Add(teacher);

            await _context.SaveChangesAsync();

            return teacher;
        }

        public async Task<Teacher?> UpdateTeacherAsync(Teacher teacher)
        {
            var existingTeacher = await _context.Teachers
                .FindAsync(teacher.TeacherId);

            if (existingTeacher == null)
            {
                return null;
            }

            existingTeacher.UserId = teacher.UserId;
            existingTeacher.EmployeeCode = teacher.EmployeeCode;
            existingTeacher.Specialization = teacher.Specialization;

            await _context.SaveChangesAsync();

            return existingTeacher;
        }

        public async Task<bool> DeleteTeacherAsync(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);

            if (teacher == null)
            {
                return false;
            }

            _context.Teachers.Remove(teacher);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}