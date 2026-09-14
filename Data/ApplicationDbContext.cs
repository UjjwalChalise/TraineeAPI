using Microsoft.EntityFrameworkCore;
using TraineeAPI.Models;

namespace TraineeAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

        public DbSet<Attendance> Attendances { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        public DbSet<Module> Modules { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }



    }
}