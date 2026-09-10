using Microsoft.EntityFrameworkCore;
using TraineeAPI.Models;

namespace TraineeAPI.Data;

public class TraineeDbContext : DbContext
{
    public TraineeDbContext(
        DbContextOptions<TraineeDbContext> options)
        : base(options)
    {
    }

    public DbSet<Course> Courses { get; set; }
    public DbSet<Student> Students { get; set; }

    public DbSet<Teacher> Teachers { get; set; }

    public DbSet<Module> Modules { get; set; }

    public DbSet<Assignment> Assignments { get; set; }
}