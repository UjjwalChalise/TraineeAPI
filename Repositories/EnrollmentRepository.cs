using Microsoft.EntityFrameworkCore;
using TraineeAPI.Data;
using TraineeAPI.Models;

namespace TraineeAPI.Repositories;

public class EnrollmentRepository : IEnrollmentRepository
{
    private readonly AppDbContext _context;

    public EnrollmentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Enrollment>> GetAllAsync()
        => await _context.Enrollments.ToListAsync();

    public async Task<Enrollment?> GetByIdAsync(int id)
        => await _context.Enrollments.FindAsync(id);

    public async Task<bool> ExistsAsync(int studentId, int moduleId)
        => await _context.Enrollments
            .AnyAsync(e => e.StudentId == studentId && e.ModuleId == moduleId);

    public async Task AddAsync(Enrollment enrollment)
        => await _context.Enrollments.AddAsync(enrollment);

    public void Delete(Enrollment enrollment)
        => _context.Enrollments.Remove(enrollment);

    public async Task<bool> SaveChangesAsync()
        => await _context.SaveChangesAsync() > 0;
}