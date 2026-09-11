using Microsoft.EntityFrameworkCore;
using TraineeAPI.Data;
using TraineeAPI.Models;

namespace TraineeAPI.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly AppDbContext _context;

    public CourseRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<Course>> GetAllAsync()
        => await _context.Courses.Include(c => c.Module).ToListAsync();

    public async Task<Course?> GetByIdAsync(int id)
        => await _context.Courses.Include(c => c.Module).FirstOrDefaultAsync(c => c.Id == id);

    public async Task AddAsync(Course course) => await _context.Courses.AddAsync(course);
    public void Update(Course course) => _context.Courses.Update(course);
    public void Delete(Course course) => _context.Courses.Remove(course);
    public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;
}