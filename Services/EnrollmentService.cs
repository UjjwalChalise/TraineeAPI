using TraineeAPI.Models;
using TraineeAPI.Repositories.Interfaces;
using TraineeAPI.Services.Interfaces;

namespace TraineeAPI.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<IEnumerable<Enrollment>> GetAllEnrollmentsAsync()
        {
            return await _enrollmentRepository.GetAllEnrollmentsAsync();
        }

        public async Task<Enrollment?> GetEnrollmentByIdAsync(int id)
        {
            return await _enrollmentRepository.GetEnrollmentByIdAsync(id);
        }

        public async Task<Enrollment> AddEnrollmentAsync(Enrollment enrollment)
        {
            return await _enrollmentRepository.AddEnrollmentAsync(enrollment);
        }

        public async Task<Enrollment?> UpdateEnrollmentAsync(Enrollment enrollment)
        {
            return await _enrollmentRepository.UpdateEnrollmentAsync(enrollment);
        }

        public async Task<bool> DeleteEnrollmentAsync(int id)
        {
            return await _enrollmentRepository.DeleteEnrollmentAsync(id);
        }
    }
}