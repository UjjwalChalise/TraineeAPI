using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TraineeAPI.Models;

namespace TraineeMVC.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Course> Courses { get; set; }
    public DbSet<Student> Students { get; set; }

    public DbSet<Teacher> Teachers { get; set; }

    public DbSet<Module> Modules { get; set; }

    public DbSet<UserDetails> UserDetails { get; set; }
}