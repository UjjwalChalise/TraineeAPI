using Microsoft.EntityFrameworkCore;
using TraineeAPI.Data;
using TraineeAPI.Models;

namespace TraineeAPI.Repositories;

public class TeacherRepository : ITeacherRepository
{
    private readonly TraineeDbContext _context;

    public TeacherRepository(TraineeDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Teacher>> GetAllAsync()
    {
        return await _context.Teachers.ToListAsync();
    }
}