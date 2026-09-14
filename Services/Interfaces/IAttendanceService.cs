using TraineeAPI.Models;

namespace TraineeAPI.Services.Interfaces
{
    public interface IAttendanceService
    {
        Task<IEnumerable<Attendance>> GetAllAttendancesAsync();

        Task<Attendance?> GetAttendanceByIdAsync(int id);

        Task<Attendance> AddAttendanceAsync(Attendance attendance);

        Task<Attendance?> UpdateAttendanceAsync(Attendance attendance);

        Task<bool> DeleteAttendanceAsync(int id);
    }
}