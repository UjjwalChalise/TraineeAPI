using Microsoft.EntityFrameworkCore;
using TraineeAPI.Data;
using TraineeAPI.Models;

namespace TraineeAPI.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly AppDbContext _context;

    public StudentRepository(AppDbContext context) => _context = context;

    public async Task<Student?> GetByIdAsync(int id)
        => await _context.Students.Include(s => s.UserDetails).FirstOrDefaultAsync(s => s.Id == id);

    public async Task AddAsync(Student student) => await _context.Students.AddAsync(student);
    public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;
}