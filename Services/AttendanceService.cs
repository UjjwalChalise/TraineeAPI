using TraineeAPI.Models;
using TraineeAPI.Repositories.Interfaces;
using TraineeAPI.Services.Interfaces;

namespace TraineeAPI.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceService(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public async Task<IEnumerable<Attendance>> GetAllAttendancesAsync()
        {
            return await _attendanceRepository.GetAllAttendancesAsync();
        }

        public async Task<Attendance?> GetAttendanceByIdAsync(int id)
        {
            return await _attendanceRepository.GetAttendanceByIdAsync(id);
        }

        public async Task<Attendance> AddAttendanceAsync(Attendance attendance)
        {
            return await _attendanceRepository.AddAttendanceAsync(attendance);
        }

        public async Task<Attendance?> UpdateAttendanceAsync(Attendance attendance)
        {
            return await _attendanceRepository.UpdateAttendanceAsync(attendance);
        }

        public async Task<bool> DeleteAttendanceAsync(int id)
        {
            return await _attendanceRepository.DeleteAttendanceAsync(id);
        }
    }
}