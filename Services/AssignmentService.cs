using TraineeAPI.Models;
using TraineeAPI.Repositories.Interfaces;
using TraineeAPI.Services.Interfaces;

namespace TraineeAPI.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public AssignmentService(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        public async Task<IEnumerable<Assignment>> GetAllAssignmentsAsync()
        {
            return await _assignmentRepository.GetAllAsync();
        }

        public async Task<Assignment?> GetAssignmentByIdAsync(int id)
        {
            return await _assignmentRepository.GetByIdAsync(id);
        }

        public async Task<Assignment> CreateAssignmentAsync(Assignment assignment)
        {
            return await _assignmentRepository.AddAsync(assignment);
        }

        public async Task<Assignment?> UpdateAssignmentAsync(Assignment assignment)
        {
            return await _assignmentRepository.UpdateAsync(assignment);
        }

        public async Task<bool> DeleteAssignmentAsync(int id)
        {
            return await _assignmentRepository.DeleteAsync(id);
        }
    }
}