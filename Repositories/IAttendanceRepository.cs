using TraineeAPI.Models;

namespace TraineeAPI.Repositories;

public interface IAttendanceRepository
{
    Task<IEnumerable<Attendance>> GetBySessionIdAsync(int sessionId);
    Task<Attendance?> GetByIdAsync(int id);
    Task<Attendance?> GetBySessionAndStudentAsync(int sessionId, int studentId);
    Task AddAsync(Attendance attendance);
    void Update(Attendance attendance);
    Task<bool> SaveChangesAsync();
}