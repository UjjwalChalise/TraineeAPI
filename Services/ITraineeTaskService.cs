using TraineeAPI.Models;

namespace TraineeAPI.Services
{
    public interface ITraineeTaskService
    {
        Task<IEnumerable<TraineeTask>> GetAllAsync();

        Task<TraineeTask?> GetByIdAsync(int id);

        Task<TraineeTask> CreateAsync(TraineeTask traineeTask);

        Task<TraineeTask?> UpdateAsync(int id, TraineeTask traineeTask);

        Task<bool> DeleteAsync(int id);
    }
}