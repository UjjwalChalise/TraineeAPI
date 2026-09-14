using TraineeAPI.Models;
using TraineeAPI.Repositories;

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

        public async Task<Assignment> AddAsync(Assignment assignment)
        {
            return await _assignmentRepository.AddAsync(assignment);
        }

        public async Task<bool> UpdateAsync(Assignment assignment)
        {
            return await _assignmentRepository.UpdateAsync(assignment);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _assignmentRepository.DeleteAsync(id);
        }
    }
}