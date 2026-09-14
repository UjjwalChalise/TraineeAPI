using TraineeAPI.Models;

namespace TraineeAPI.Services.Interfaces
{
    public interface IEnrollmentService
    {
        Task<IEnumerable<Enrollment>> GetAllEnrollmentsAsync();

        Task<Enrollment?> GetEnrollmentByIdAsync(int id);

        Task<Enrollment> AddEnrollmentAsync(Enrollment enrollment);

        Task<Enrollment?> UpdateEnrollmentAsync(Enrollment enrollment);

        Task<bool> DeleteEnrollmentAsync(int id);
    }
}