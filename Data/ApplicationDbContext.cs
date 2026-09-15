using Microsoft.EntityFrameworkCore;
using TraineeAPI.Models;

namespace TraineeAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // =====================================================
        // DbSets
        // =====================================================

        public DbSet<UserDetails> UserDetails { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Module> Modules { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        public DbSet<Assignment> Assignments { get; set; }

        public DbSet<AssignmentSubmission> AssignmentSubmissions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // =====================================================
            // USER DETAILS -> STUDENT
            // One UserDetails -> One Student
            // =====================================================

            modelBuilder.Entity<Student>()
                .HasOne(s => s.UserDetails)
                .WithOne()
                .HasForeignKey<Student>(s => s.UserDetailsId)
                .OnDelete(DeleteBehavior.NoAction);


            // =====================================================
            // USER DETAILS -> TEACHER
            // One UserDetails -> One Teacher
            // =====================================================

            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.UserDetails)
                .WithOne()
                .HasForeignKey<Teacher>(t => t.UserDetailsId)
                .OnDelete(DeleteBehavior.NoAction);


            // =====================================================
            // TEACHER -> COURSE
            // One Teacher -> Many Courses
            //
            // NoAction prevents multiple cascade paths
            // =====================================================

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Teacher)
                .WithMany(t => t.Courses)
                .HasForeignKey(c => c.TeacherId)
                .OnDelete(DeleteBehavior.NoAction);


            // =====================================================
            // COURSE -> MODULE
            // One Course -> Many Modules
            // =====================================================

            modelBuilder.Entity<Module>()
                .HasOne(m => m.Course)
                .WithMany(c => c.Modules)
                .HasForeignKey(m => m.CourseId)
                .OnDelete(DeleteBehavior.Cascade);


            // =====================================================
            // COURSE -> ENROLLMENT
            // One Course -> Many Enrollments
            // =====================================================

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.NoAction);


            // =====================================================
            // STUDENT -> ENROLLMENT
            // One Student -> Many Enrollments
            // =====================================================

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.NoAction);


            // =====================================================
            // MODULE -> ASSIGNMENT
            // One Module -> Many Assignments
            // =====================================================

            modelBuilder.Entity<Assignment>()
                .HasOne(a => a.Module)
                .WithMany()
                .HasForeignKey(a => a.ModuleId)
                .OnDelete(DeleteBehavior.Cascade);


            // =====================================================
            // ASSIGNMENT -> ASSIGNMENT SUBMISSION
            // One Assignment -> Many Submissions
            // =====================================================

            modelBuilder.Entity<AssignmentSubmission>()
                .HasOne(s => s.Assignment)
                .WithMany()
                .HasForeignKey(s => s.AssignmentId)
                .OnDelete(DeleteBehavior.NoAction);


            // =====================================================
            // STUDENT -> ASSIGNMENT SUBMISSION
            // One Student -> Many Submissions
            // =====================================================

            modelBuilder.Entity<AssignmentSubmission>()
                .HasOne(s => s.Student)
                .WithMany(st => st.Submissions)
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.NoAction);


            // =====================================================
            // USER EMAIL MUST BE UNIQUE
            // =====================================================

            modelBuilder.Entity<UserDetails>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}