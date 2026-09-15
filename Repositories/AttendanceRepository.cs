using Microsoft.EntityFrameworkCore;
using TraineeAPI.Data;
using TraineeAPI.Models;

namespace TraineeAPI.Repositories;

public class AttendanceRepository : IAttendanceRepository
{
    private readonly TraineeDbContext _context;

    public AttendanceRepository(TraineeDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Attendance>> GetAllAsync()
    {
        return await _context.Attendances
            .Include(a => a.Student)
            .ToListAsync();
    }
}