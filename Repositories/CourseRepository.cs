using Microsoft.EntityFrameworkCore;
using TraineeAPI.Data;
using TraineeAPI.Models;

namespace TraineeAPI.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly TraineeDbContext _context;

    public CourseRepository(
        TraineeDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Course>>
        GetAllAsync()
    {
        return await _context.Courses.ToListAsync();
    }
}