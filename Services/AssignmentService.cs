using TraineeAPI.Models;
using TraineeAPI.Repository;

namespace TraineeAPI.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public AssignmentService(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        public async Task<IEnumerable<Assignment>> GetAllAsync()
        {
            return await _assignmentRepository.GetAllAsync();
        }

        public async Task<Assignment?> GetByIdAsync(int id)
        {
            return await _assignmentRepository.GetByIdAsync(id);
        }

        public async Task<Assignment> CreateAsync(Assignment assignment)
        {
            return await _assignmentRepository.CreateAsync(assignment);
        }

        public async Task<Assignment?> UpdateAsync(int id, Assignment assignment)
        {
            return await _assignmentRepository.UpdateAsync(id, assignment);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _assignmentRepository.DeleteAsync(id);
        }
    }
}