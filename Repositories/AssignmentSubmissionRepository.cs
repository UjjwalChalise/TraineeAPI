using Microsoft.EntityFrameworkCore;
using TraineeAPI.Data;
using TraineeAPI.Models;

namespace TraineeAPI.Repositories;

public class AssignmentSubmissionRepository : IAssignmentSubmissionRepository
{
    private readonly AppDbContext _context;

    public AssignmentSubmissionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AssignmentSubmission>> GetByAssignmentIdAsync(int assignmentId)
        => await _context.AssignmentSubmissions
            .Include(s => s.Assignment)
            .Where(s => s.AssignmentId == assignmentId)
            .ToListAsync();

    public async Task<AssignmentSubmission?> GetByIdAsync(int id)
        => await _context.AssignmentSubmissions
            .Include(s => s.Assignment)
            .FirstOrDefaultAsync(s => s.Id == id);

    public async Task<int> CountByAssignmentAndStudentAsync(int assignmentId, int studentId)
        => await _context.AssignmentSubmissions
            .CountAsync(s => s.AssignmentId == assignmentId && s.StudentId == studentId);

    public async Task AddAsync(AssignmentSubmission submission)
        => await _context.AssignmentSubmissions.AddAsync(submission);

    public async Task<bool> SaveChangesAsync()
        => await _context.SaveChangesAsync() > 0;
}