using Microsoft.EntityFrameworkCore;
using TraineeAPI.Data;
using TraineeAPI.Models;
using TraineeAPI.Repositories.Interfaces;

namespace TraineeAPI.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDbContext _context;

        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Attendance>> GetAllAttendancesAsync()
        {
            return await _context.Attendances
                .Include(a => a.Student)
                .Include(a => a.Course)
                .ToListAsync();
        }

        public async Task<Attendance?> GetAttendanceByIdAsync(int id)
        {
            return await _context.Attendances
                .Include(a => a.Student)
                .Include(a => a.Course)
                .FirstOrDefaultAsync(a => a.AttendanceId == id);
        }

        public async Task<Attendance> AddAttendanceAsync(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();

            return attendance;
        }

        public async Task<Attendance?> UpdateAttendanceAsync(Attendance attendance)
        {
            var existingAttendance =
                await _context.Attendances.FindAsync(attendance.AttendanceId);

            if (existingAttendance == null)
            {
                return null;
            }

            existingAttendance.StudentId = attendance.StudentId;
            existingAttendance.CourseId = attendance.CourseId;
            existingAttendance.Date = attendance.Date;
            existingAttendance.Status = attendance.Status;

            await _context.SaveChangesAsync();

            return existingAttendance;
        }

        public async Task<bool> DeleteAttendanceAsync(int id)
        {
            var attendance = await _context.Attendances.FindAsync(id);

            if (attendance == null)
            {
                return false;
            }

            _context.Attendances.Remove(attendance);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}