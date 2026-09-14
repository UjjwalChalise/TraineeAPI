using TraineeAPI.Models;
using TraineeAPI.Repository;

namespace TraineeAPI.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceService(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public async Task<IEnumerable<Attendance>> GetAllAsync()
        {
            return await _attendanceRepository.GetAllAsync();
        }

        public async Task<Attendance?> GetByIdAsync(int id)
        {
            return await _attendanceRepository.GetByIdAsync(id);
        }

        public async Task<Attendance> CreateAsync(Attendance attendance)
        {
            return await _attendanceRepository.CreateAsync(attendance);
        }

        public async Task<Attendance?> UpdateAsync(int id, Attendance attendance)
        {
            return await _attendanceRepository.UpdateAsync(id, attendance);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _attendanceRepository.DeleteAsync(id);
        }
    }
}