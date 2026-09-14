using TraineeAPI.Models;
using TraineeAPI.Repositories;
using TraineeAPI.Services;

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

        public async Task<Attendance> AddAsync(Attendance attendance)
        {
            return await _attendanceRepository.AddAsync(attendance);
        }

        public async Task<bool> UpdateAsync(Attendance attendance)
        {
            return await _attendanceRepository.UpdateAsync(attendance);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _attendanceRepository.DeleteAsync(id);
        }
    }
}