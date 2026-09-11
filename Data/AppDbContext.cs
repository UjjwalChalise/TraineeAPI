using Microsoft.EntityFrameworkCore;
using TraineeAPI.Models;

namespace TraineeAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<UserDetails> UserDetails => Set<UserDetails>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Teacher> Teachers => Set<Teacher>();
    public DbSet<Module> Modules => Set<Module>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<CourseTeacher> CourseTeachers => Set<CourseTeacher>();
    public DbSet<Enrollment> Enrollments => Set<Enrollment>();
    public DbSet<Assignment> Assignments => Set<Assignment>();
    public DbSet<AssignmentSubmission> AssignmentSubmissions => Set<AssignmentSubmission>();
    public DbSet<CourseSession> CourseSessions => Set<CourseSession>();
    public DbSet<Attendance> Attendances => Set<Attendance>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CourseTeacher>()
            .HasKey(ct => new { ct.CourseId, ct.TeacherId });

        modelBuilder.Entity<Assignment>()
            .Property(a => a.MaximumMarks)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Student)
            .WithMany(s => s.Enrollments)
            .HasForeignKey(e => e.StudentId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Module)
            .WithMany(m => m.Enrollments)
            .HasForeignKey(e => e.ModuleId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Course>()
        .HasOne(c => c.Module)
        .WithMany(m => m.Courses)
        .HasForeignKey(c => c.ModuleId)
        .OnDelete(DeleteBehavior.NoAction);

        base.OnModelCreating(modelBuilder);
    }


}