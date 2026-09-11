using Microsoft.EntityFrameworkCore;
using TraineeAPI.Models;

namespace TraineeAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<UserDetails>()
            .HasOne(u => u.Student)
            .WithOne(s => s.UserDetails)
            .HasForeignKey<Student>(s => s.UserDetailsId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<UserDetails>()
            .HasOne(u => u.Teacher)
            .WithOne(t => t.UserDetails)
            .HasForeignKey<Teacher>(t => t.UserDetailsId)
            .OnDelete(DeleteBehavior.Cascade);
    }
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<UserDetails> UserDetails => Set<UserDetails>();

    public DbSet<Student> Students => Set<Student>();

    public DbSet<Teacher> Teachers => Set<Teacher>();


}