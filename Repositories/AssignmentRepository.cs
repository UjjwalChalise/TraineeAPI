using Microsoft.EntityFrameworkCore;
using TraineeAPI.Data;
using TraineeAPI.Models;

namespace TraineeAPI.Repositories;

public class AssignmentRepository : IAssignmentRepository
{
    private readonly AppDbContext _context;

    public AssignmentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Assignment>> GetAllAsync()
        => await _context.Assignments.Include(a => a.Course).ToListAsync();

    public async Task<IEnumerable<Assignment>> GetByCourseIdAsync(int courseId)
        => await _context.Assignments
            .Include(a => a.Course)
            .Where(a => a.CourseId == courseId)
            .ToListAsync();

    public async Task<Assignment?> GetByIdAsync(int id)
        => await _context.Assignments.Include(a => a.Course)
            .FirstOrDefaultAsync(a => a.Id == id);

    public async Task AddAsync(Assignment assignment)
        => await _context.Assignments.AddAsync(assignment);

    public void Update(Assignment assignment)
        => _context.Assignments.Update(assignment);

    public void Delete(Assignment assignment)
        => _context.Assignments.Remove(assignment);

    public async Task<bool> SaveChangesAsync()
        => await _context.SaveChangesAsync() > 0;
}