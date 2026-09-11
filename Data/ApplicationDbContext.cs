using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TraineeAPI.Models;

namespace TraineeAPI.Data
{
    public class ApplicationDbContext
        : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserDetails> UserDetails => Set<UserDetails>();
        public DbSet<Teacher> Teachers => Set<Teacher>();
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Module> Modules => Set<Module>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Assignment> Assignments => Set<Assignment>();
        public DbSet<CourseTeacher> CourseTeachers => Set<CourseTeacher>();
        public DbSet<Enrollment> Enrollments => Set<Enrollment>();
        public DbSet<AssignmentSubmission> AssignmentSubmissions => Set<AssignmentSubmission>();
        public DbSet<CourseSession> CourseSessions => Set<CourseSession>();
        public DbSet<Attendance> Attendances => Set<Attendance>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // ApplicationUser -> UserDetails
            builder.Entity<ApplicationUser>()
                .HasOne(u => u.UserDetails)
                .WithOne(d => d.ApplicationUser)
                .HasForeignKey<UserDetails>(d => d.ApplicationUserId)
                .OnDelete(DeleteBehavior.Cascade);

            // UserDetails -> Teacher
            builder.Entity<UserDetails>()
                .HasOne(u => u.Teacher)
                .WithOne(t => t.UserDetails)
                .HasForeignKey<Teacher>(t => t.UserDetailsId)
                .OnDelete(DeleteBehavior.Cascade);

            // UserDetails -> Student
            builder.Entity<UserDetails>()
                .HasOne(u => u.Student)
                .WithOne(s => s.UserDetails)
                .HasForeignKey<Student>(s => s.UserDetailsId)
                .OnDelete(DeleteBehavior.Cascade);

            // Module -> Course
            builder.Entity<Course>()
                .HasOne(c => c.Module)
                .WithMany(m => m.Courses)
                .HasForeignKey(c => c.ModuleId)
                .OnDelete(DeleteBehavior.SetNull);

            // Teacher <-> Course
            builder.Entity<CourseTeacher>()
                .HasKey(ct => new { ct.CourseId, ct.TeacherId });

            builder.Entity<CourseTeacher>()
                .HasOne(ct => ct.Course)
                .WithMany(c => c.CourseTeachers)
                .HasForeignKey(ct => ct.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CourseTeacher>()
                .HasOne(ct => ct.Teacher)
                .WithMany(t => t.CourseTeachers)
                .HasForeignKey(ct => ct.TeacherId)
                .OnDelete(DeleteBehavior.Cascade);

            // Student <-> Course through Enrollment
            builder.Entity<Enrollment>()
                .HasIndex(e => new { e.StudentId, e.CourseId })
                .IsUnique();

            builder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            // Course -> Assignment
            builder.Entity<Assignment>()
                .HasOne(a => a.Course)
                .WithMany(c => c.Assignments)
                .HasForeignKey(a => a.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            // Assignment -> Submission
            builder.Entity<AssignmentSubmission>()
                .HasOne(s => s.Assignment)
                .WithMany(a => a.Submissions)
                .HasForeignKey(s => s.AssignmentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<AssignmentSubmission>()
                .HasOne(s => s.Student)
                .WithMany(st => st.AssignmentSubmissions)
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<AssignmentSubmission>()
                .HasIndex(s => new { s.AssignmentId, s.StudentId })
                .IsUnique();

            // Course -> CourseSession
            builder.Entity<CourseSession>()
                .HasOne(s => s.Course)
                .WithMany(c => c.CourseSessions)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            // CourseSession -> Attendance
            builder.Entity<Attendance>()
                .HasOne(a => a.CourseSession)
                .WithMany(s => s.Attendances)
                .HasForeignKey(a => a.CourseSessionId)
                .OnDelete(DeleteBehavior.Cascade);

            // Student -> Attendance
            builder.Entity<Attendance>()
                .HasOne(a => a.Student)
                .WithMany(s => s.Attendances)
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Attendance>()
                .HasIndex(a => new { a.CourseSessionId, a.StudentId })
                .IsUnique();
        }
    }
}