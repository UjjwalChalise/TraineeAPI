using Microsoft.EntityFrameworkCore;
using TraineeAPI.Data;
using TraineeAPI.Models;
using TraineeAPI.Repositories.Interfaces;

namespace TraineeAPI.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Enrollment>> GetAllEnrollmentsAsync()
        {
            return await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .ToListAsync();
        }

        public async Task<Enrollment?> GetEnrollmentByIdAsync(int id)
        {
            return await _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .FirstOrDefaultAsync(e => e.EnrollmentId == id);
        }

        public async Task<Enrollment> AddEnrollmentAsync(Enrollment enrollment)
        {
            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();

            return enrollment;
        }

        public async Task<Enrollment?> UpdateEnrollmentAsync(Enrollment enrollment)
        {
            var existingEnrollment =
                await _context.Enrollments.FindAsync(enrollment.EnrollmentId);

            if (existingEnrollment == null)
            {
                return null;
            }

            existingEnrollment.StudentId = enrollment.StudentId;
            existingEnrollment.CourseId = enrollment.CourseId;
            existingEnrollment.EnrolledDate = enrollment.EnrolledDate;

            await _context.SaveChangesAsync();

            return existingEnrollment;
        }

        public async Task<bool> DeleteEnrollmentAsync(int id)
        {
            var enrollment =
                await _context.Enrollments.FindAsync(id);

            if (enrollment == null)
            {
                return false;
            }

            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}