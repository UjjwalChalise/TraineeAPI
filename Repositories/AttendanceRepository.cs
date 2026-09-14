using Microsoft.EntityFrameworkCore;
using TraineeAPI.Data;
using TraineeAPI.Models;
using TraineeAPI.Repositories;

namespace TraineeAPI.Repositories
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
            return await _context.Attendances.ToListAsync();
        }

        public async Task<Attendance?> GetByIdAsync(int id)
        {
            return await _context.Attendances.FindAsync(id);
        }

        public async Task<Attendance> AddAsync(Attendance attendance)
        {
            _context.Attendances.Add(attendance);

            await _context.SaveChangesAsync();

            return attendance;
        }

        public async Task<bool> UpdateAsync(Attendance attendance)
        {
            var existingAttendance =
                await _context.Attendances.FindAsync(attendance.Id);

            if (existingAttendance == null)
            {
                return false;
            }

            existingAttendance.CourseSessionId = attendance.CourseSessionId;
            existingAttendance.StudentId = attendance.StudentId;
            existingAttendance.Status = attendance.Status;
            existingAttendance.Remarks = attendance.Remarks;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var attendance =
                await _context.Attendances.FindAsync(id);

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