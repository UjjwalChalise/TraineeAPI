using TraineeAPI.Models;

namespace TraineeAPI.Repositories.Interfaces
{
    public interface IEnrollmentRepository
    {
        Task<IEnumerable<Enrollment>> GetAllEnrollmentsAsync();

        Task<Enrollment?> GetEnrollmentByIdAsync(int id);

        Task<Enrollment> AddEnrollmentAsync(Enrollment enrollment);

        Task<Enrollment?> UpdateEnrollmentAsync(Enrollment enrollment);

        Task<bool> DeleteEnrollmentAsync(int id);
    }
}