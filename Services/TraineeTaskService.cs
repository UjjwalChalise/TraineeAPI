using TraineeAPI.Models;
using TraineeAPI.Repository;

namespace TraineeAPI.Services
{
    public class TraineeTaskService : ITraineeTaskService
    {
        private readonly ITraineeTaskRepository _traineeTaskRepository;

        public TraineeTaskService(ITraineeTaskRepository traineeTaskRepository)
        {
            _traineeTaskRepository = traineeTaskRepository;
        }

        public async Task<IEnumerable<TraineeTask>> GetAllAsync()
        {
            return await _traineeTaskRepository.GetAllAsync();
        }

        public async Task<TraineeTask?> GetByIdAsync(int id)
        {
            return await _traineeTaskRepository.GetByIdAsync(id);
        }

        public async Task<TraineeTask> CreateAsync(TraineeTask traineeTask)
        {
            return await _traineeTaskRepository.CreateAsync(traineeTask);
        }

        public async Task<TraineeTask?> UpdateAsync(int id, TraineeTask traineeTask)
        {
            return await _traineeTaskRepository.UpdateAsync(id, traineeTask);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _traineeTaskRepository.DeleteAsync(id);
        }
    }
}