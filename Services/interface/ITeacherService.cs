using TraineeAPI.Models;

namespace TraineeAPI.Services.@interface;

public interface ITeacherService
{
    Task<IEnumerable<Teacher>> GetAllAsync();
}