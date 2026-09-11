using Microsoft.EntityFrameworkCore;
using TraineeAPI.Models;

namespace TraineeAPI.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(
       DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Module> Modules { get; set; }

        public DbSet<Assignment> Assignments { get; set; }
    }
}
