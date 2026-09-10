using Microsoft.EntityFrameworkCore;
using TraineeAPI.Data;
using TraineeAPI.Models;

namespace TraineeAPI.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly TraineeDbContext _context;

    public StudentRepository(TraineeDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Student>> GetAllAsync()
    {
        return await _context.Students.ToListAsync();
    }
}