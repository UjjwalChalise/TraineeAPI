using TraineeAPI.Models;

namespace TraineeAPI.Repository
{
    public interface IAttendanceRepository
    {
        Task<IEnumerable<Attendance>> GetAllAsync();

        Task<Attendance?> GetByIdAsync(int id);

        Task<Attendance> CreateAsync(Attendance attendance);

        Task<Attendance?> UpdateAsync(int id, Attendance attendance);

        Task<bool> DeleteAsync(int id);
    }
}