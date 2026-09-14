using TraineeAPI.Models;

namespace TraineeAPI.Repository
{
    public interface ITraineeTaskRepository
    {
        Task<IEnumerable<TraineeTask>> GetAllAsync();

        Task<TraineeTask?> GetByIdAsync(int id);

        Task<TraineeTask> CreateAsync(TraineeTask traineeTask);

        Task<TraineeTask?> UpdateAsync(int id, TraineeTask traineeTask);

        Task<bool> DeleteAsync(int id);
    }
}