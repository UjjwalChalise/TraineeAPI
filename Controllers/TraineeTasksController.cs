using Microsoft.AspNetCore.Mvc;
using TraineeAPI.Models;
using TraineeAPI.Services;

namespace TraineeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraineeTasksController : ControllerBase
    {
        private readonly ITraineeTaskService _traineeTaskService;

        public TraineeTasksController(ITraineeTaskService traineeTaskService)
        {
            _traineeTaskService = traineeTaskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTraineeTasks()
        {
            var traineeTasks = await _traineeTaskService.GetAllAsync();

            return Ok(traineeTasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTraineeTask(int id)
        {
            var traineeTask =
                await _traineeTaskService.GetByIdAsync(id);

            if (traineeTask == null)
                return NotFound();

            return Ok(traineeTask);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTraineeTask(
            TraineeTask traineeTask)
        {
            var createdTask =
                await _traineeTaskService.CreateAsync(traineeTask);

            return Ok(createdTask);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTraineeTask(
            int id,
            TraineeTask traineeTask)
        {
            var updatedTask =
                await _traineeTaskService.UpdateAsync(id, traineeTask);

            if (updatedTask == null)
                return NotFound();

            return Ok(updatedTask);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTraineeTask(int id)
        {
            var deleted =
                await _traineeTaskService.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}