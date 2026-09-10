using Microsoft.EntityFrameworkCore;
using TraineeAPI.Data;
using TraineeAPI.Models;

namespace TraineeAPI.Repositories;

public class AssignmentRepository : IAssignmentRepository
{
    private readonly TraineeDbContext _context;

    public AssignmentRepository(TraineeDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Assignment>> GetAllAsync()
    {
        return await _context.Assignments
            .Include(a => a.Module)
            .ToListAsync();
    }
}