using TraineeAPI.Models;

namespace TraineeAPI.Repositories
{
    public interface IAttendanceRepository
    {
        Task<IEnumerable<Attendance>> GetAllAsync();

        Task<Attendance?> GetByIdAsync(int id);

        Task<Attendance> AddAsync(Attendance attendance);

        Task<bool> UpdateAsync(Attendance attendance);

        Task<bool> DeleteAsync(int id);
    }
}
