using Microsoft.EntityFrameworkCore;
using TraineeAPI.Data;
using TraineeAPI.Models;

namespace TraineeAPI.Repositories;

public class TeacherRepository : ITeacherRepository
{
    private readonly AppDbContext _context;

    public TeacherRepository(AppDbContext context) => _context = context;

    public async Task<Teacher?> GetByIdAsync(int id)
        => await _context.Teachers.Include(t => t.UserDetails).FirstOrDefaultAsync(t => t.Id == id);

    public async Task AddAsync(Teacher teacher) => await _context.Teachers.AddAsync(teacher);
    public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;
}