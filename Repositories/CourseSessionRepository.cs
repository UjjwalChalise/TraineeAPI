using Microsoft.EntityFrameworkCore;
using TraineeAPI.Data;
using TraineeAPI.Models;

namespace TraineeAPI.Repositories;

public class CourseSessionRepository : ICourseSessionRepository
{
    private readonly AppDbContext _context;

    public CourseSessionRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<CourseSession>> GetByCourseIdAsync(int courseId)
        => await _context.CourseSessions.Include(s => s.Course)
            .Where(s => s.CourseId == courseId).ToListAsync();

    public async Task<CourseSession?> GetByIdAsync(int id)
        => await _context.CourseSessions.Include(s => s.Course)
            .FirstOrDefaultAsync(s => s.Id == id);

    public async Task AddAsync(CourseSession session) => await _context.CourseSessions.AddAsync(session);
    public void Delete(CourseSession session) => _context.CourseSessions.Remove(session);
    public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;
}