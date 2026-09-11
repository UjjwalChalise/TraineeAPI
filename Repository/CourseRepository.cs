using Microsoft.EntityFrameworkCore;
using TraineeAPI.Data;
using TraineeAPI.Models;

namespace TraineeAPI.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;

        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course?> GetByIdAsync(int id)
        {
            return await _context.Courses.FindAsync(id);
        }

        public async Task<Course> CreateAsync(Course course)
        {
            _context.Courses.Add(course);

            await _context.SaveChangesAsync();

            return course;
        }

        public async Task<Course?> UpdateAsync(int id, Course course)
        {
            var existingCourse =
                await _context.Courses.FindAsync(id);

            if (existingCourse == null)
                return null;

            existingCourse.CourseName = course.CourseName;
            existingCourse.Description = course.Description;

            await _context.SaveChangesAsync();

            return existingCourse;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var course =
                await _context.Courses.FindAsync(id);

            if (course == null)
                return false;

            _context.Courses.Remove(course);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}