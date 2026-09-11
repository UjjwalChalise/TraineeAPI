using TraineeAPI.Models;

namespace TraineeAPI.Repositories;

public interface IStudentRepository
{
    Task<Student?> GetByIdAsync(int id);
    Task AddAsync(Student student);
    Task<bool> SaveChangesAsync();
}