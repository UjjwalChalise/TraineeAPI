using Microsoft.EntityFrameworkCore;
using TraineeAPI.Data;
using TraineeAPI.Models;

namespace TraineeAPI.Repositories;

public class AttendanceRepository : IAttendanceRepository
{
    private readonly AppDbContext _context;

    public AttendanceRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<Attendance>> GetBySessionIdAsync(int sessionId)
        => await _context.Attendances.Where(a => a.CourseSessionId == sessionId).ToListAsync();

    public async Task<Attendance?> GetByIdAsync(int id)
        => await _context.Attendances.FindAsync(id);

    public async Task<Attendance?> GetBySessionAndStudentAsync(int sessionId, int studentId)
        => await _context.Attendances
            .FirstOrDefaultAsync(a => a.CourseSessionId == sessionId && a.StudentId == studentId);

    public async Task AddAsync(Attendance attendance) => await _context.Attendances.AddAsync(attendance);
    public void Update(Attendance attendance) => _context.Attendances.Update(attendance);
    public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;
}