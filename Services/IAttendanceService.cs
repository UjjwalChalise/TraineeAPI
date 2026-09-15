using TraineeAPI.Models;

namespace TraineeAPI.Services;

public interface IAttendanceService
{
    Task<IEnumerable<Attendance>> GetAllAsync();
}