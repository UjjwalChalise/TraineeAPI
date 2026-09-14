using TraineeAPI.Models;

namespace TraineeAPI.Repositories.Interfaces
{
    public interface IAttendanceRepository
    {
        Task<IEnumerable<Attendance>> GetAllAttendancesAsync();

        Task<Attendance?> GetAttendanceByIdAsync(int id);

        Task<Attendance> AddAttendanceAsync(Attendance attendance);

        Task<Attendance?> UpdateAttendanceAsync(Attendance attendance);

        Task<bool> DeleteAttendanceAsync(int id);
    }
}