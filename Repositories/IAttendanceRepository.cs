using TraineeAPI.Models;

namespace TraineeAPI.Repositories;

public interface IAttendanceRepository
{
    Task<IEnumerable<Attendance>> GetAllAsync();
}