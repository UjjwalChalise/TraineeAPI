using Microsoft.EntityFrameworkCore;
using TraineeAPI.Data;
using TraineeAPI.Models;

namespace TraineeAPI.Repository
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly AppDbContext _context;

        public AttendanceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Attendance>> GetAllAsync()
        {
            return await _context.Attendances
                .Include(a => a.Student)
                .ToListAsync();
        }

        public async Task<Attendance?> GetByIdAsync(int id)
        {
            return await _context.Attendances
                .Include(a => a.Student)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Attendance> CreateAsync(Attendance attendance)
        {
            _context.Attendances.Add(attendance);

            await _context.SaveChangesAsync();

            return attendance;
        }

        public async Task<Attendance?> UpdateAsync(int id, Attendance attendance)
        {
            var existingAttendance =
                await _context.Attendances.FindAsync(id);

            if (existingAttendance == null)
                return null;

            existingAttendance.Date = attendance.Date;
            existingAttendance.IsPresent = attendance.IsPresent;
            existingAttendance.StudentId = attendance.StudentId;

            await _context.SaveChangesAsync();

            return existingAttendance;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var attendance =
                await _context.Attendances.FindAsync(id);

            if (attendance == null)
                return false;

            _context.Attendances.Remove(attendance);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}