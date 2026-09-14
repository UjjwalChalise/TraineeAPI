using TraineeAPI.Models;
namespace TraineeAPI.Services
{
    public interface IAttendanceService
    {
        Task<IEnumerable<Attendance>> GetAllAsync();
        Task<Attendance?> GetByIdAsync(int id);
        Task<Attendance> AddAsync(Attendance attendance);
        Task<bool> UpdateAsync(Attendance attendance);
        Task<bool> DeleteAsync(int id);
    }
}