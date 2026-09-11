using Microsoft.EntityFrameworkCore;
using TraineeAPI.Models;

namespace TraineeAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Module> Modules { get; set; }

        public DbSet<Assignment> Assignments { get; set; }

        public DbSet<Attendance> Attendances { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<TraineeTask> TraineeTasks { get; set; }
    }
}