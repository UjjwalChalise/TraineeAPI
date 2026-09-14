using Microsoft.EntityFrameworkCore;
using TraineeAPI.Data;
using TraineeAPI.Models;
using TraineeAPI.Repositories.Interfaces;

namespace TraineeAPI.Repositories
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AssignmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Assignment>> GetAllAsync()
        {
            return await _context.Assignments
                .Include(a => a.Course)
                .ToListAsync();
        }

        public async Task<Assignment?> GetByIdAsync(int id)
        {
            return await _context.Assignments
                .Include(a => a.Course)
                .FirstOrDefaultAsync(a => a.AssignmentId == id);
        }

        public async Task<Assignment> AddAsync(Assignment assignment)
        {
            _context.Assignments.Add(assignment);
            await _context.SaveChangesAsync();
            return assignment;
        }

        public async Task<Assignment?> UpdateAsync(Assignment assignment)
        {
            var existingAssignment =
                await _context.Assignments.FindAsync(assignment.AssignmentId);

            if (existingAssignment == null)
                return null;

            existingAssignment.Title = assignment.Title;
            existingAssignment.Description = assignment.Description;
            existingAssignment.DueDate = assignment.DueDate;
            existingAssignment.CourseId = assignment.CourseId;

            await _context.SaveChangesAsync();

            return existingAssignment;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var assignment =
                await _context.Assignments.FindAsync(id);

            if (assignment == null)
                return false;

            _context.Assignments.Remove(assignment);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}