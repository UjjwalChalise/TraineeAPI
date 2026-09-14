using Microsoft.EntityFrameworkCore;
using TraineeAPI.Data;
using TraineeAPI.Models;

namespace TraineeAPI.Repository
{
    public class TraineeTaskRepository : ITraineeTaskRepository
    {
        private readonly AppDbContext _context;

        public TraineeTaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TraineeTask>> GetAllAsync()
        {
            return await _context.TraineeTasks.ToListAsync();
        }

        public async Task<TraineeTask?> GetByIdAsync(int id)
        {
            return await _context.TraineeTasks.FindAsync(id);
        }

        public async Task<TraineeTask> CreateAsync(TraineeTask traineeTask)
        {
            _context.TraineeTasks.Add(traineeTask);

            await _context.SaveChangesAsync();

            return traineeTask;
        }

        public async Task<TraineeTask?> UpdateAsync(int id, TraineeTask traineeTask)
        {
            var existingTask =
                await _context.TraineeTasks.FindAsync(id);

            if (existingTask == null)
                return null;

            existingTask.Title = traineeTask.Title;
            existingTask.Description = traineeTask.Description;
            existingTask.DueDate = traineeTask.DueDate;

            await _context.SaveChangesAsync();

            return existingTask;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var traineeTask =
                await _context.TraineeTasks.FindAsync(id);

            if (traineeTask == null)
                return false;

            _context.TraineeTasks.Remove(traineeTask);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}