using Microsoft.EntityFrameworkCore;
using TraineeAPI.Data;
using TraineeAPI.Models;

namespace TraineeAPI.Repository
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly AppDbContext _context;

        public AssignmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Assignment>> GetAllAsync()
        {
            return await _context.Assignments
                .Include(a => a.Module)
                .ToListAsync();
        }

        public async Task<Assignment?> GetByIdAsync(int id)
        {
            return await _context.Assignments
                .Include(a => a.Module)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Assignment> CreateAsync(Assignment assignment)
        {
            _context.Assignments.Add(assignment);

            await _context.SaveChangesAsync();

            return assignment;
        }

        public async Task<Assignment?> UpdateAsync(int id, Assignment assignment)
        {
            var existingAssignment =
                await _context.Assignments.FindAsync(id);

            if (existingAssignment == null)
                return null;

            existingAssignment.Title = assignment.Title;
            existingAssignment.Description = assignment.Description;
            existingAssignment.DueDate = assignment.DueDate;
            existingAssignment.ModuleId = assignment.ModuleId;

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