using Microsoft.EntityFrameworkCore;
using TraineeAPI.Data;
using TraineeAPI.Models;

namespace TraineeAPI.Repositories;

public class CourseTeacherRepository : ICourseTeacherRepository
{
    private readonly AppDbContext _context;

    public CourseTeacherRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CourseTeacher>> GetAllAsync()
        => await _context.CourseTeachers
            .Include(ct => ct.Course)
            .Include(ct => ct.Teacher)
                .ThenInclude(t => t.UserDetails)
            .ToListAsync();

    public async Task<CourseTeacher?> GetByIdAsync(int courseId, int teacherId)
        => await _context.CourseTeachers
            .Include(ct => ct.Course)
            .Include(ct => ct.Teacher)
                .ThenInclude(t => t.UserDetails)
            .FirstOrDefaultAsync(ct => ct.CourseId == courseId && ct.TeacherId == teacherId);

    public async Task<bool> ExistsAsync(int courseId, int teacherId)
        => await _context.CourseTeachers
            .AnyAsync(ct => ct.CourseId == courseId && ct.TeacherId == teacherId);

    public async Task AddAsync(CourseTeacher courseTeacher)
        => await _context.CourseTeachers.AddAsync(courseTeacher);

    public void Delete(CourseTeacher courseTeacher)
        => _context.CourseTeachers.Remove(courseTeacher);

    public async Task<bool> SaveChangesAsync()
        => await _context.SaveChangesAsync() > 0;
}