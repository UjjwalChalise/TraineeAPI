using Microsoft.EntityFrameworkCore;
using TraineeAPI.Models;

namespace TraineeAPI.data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Module> Modules => Set<Module>();
        public DbSet<Lesson> Lessons => Set<Lesson>();
        public DbSet<Attachment> Attachments => Set<Attachment>();
        public DbSet<Announcement> Announcements => Set<Announcement>();
        public DbSet<ApplicationUser> ApplicationUsers => Set<ApplicationUser>();
        public DbSet<UserDetails> UserDetails => Set<UserDetails>();
        public DbSet<Teacher> Teachers => Set<Teacher>();
        public DbSet<Student> Students => Set<Student>();
        public DbSet<CourseTeacher> CourseTeachers => Set<CourseTeacher>();
        public DbSet<Enrollment> Enrollments => Set<Enrollment>();
        public DbSet<LessonProgress> LessonProgresses => Set<LessonProgress>();
        public DbSet<Assignment> Assignments => Set<Assignment>();
        public DbSet<AssignmentSubmission> AssignmentSubmissions => Set<AssignmentSubmission>();
        public DbSet<Grade> Grades => Set<Grade>();
        public DbSet<Quiz> Quizzes => Set<Quiz>();
        public DbSet<Question> Questions => Set<Question>();
        public DbSet<AnswerOption> AnswerOptions => Set<AnswerOption>();
        public DbSet<QuizAttempt> QuizAttempts => Set<QuizAttempt>();
        public DbSet<CourseSession> CourseSessions => Set<CourseSession>();
        public DbSet<Attendance> Attendances => Set<Attendance>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // ---------------------------------------
            // ApplicationUser -> UserDetails
            // ---------------------------------------

            builder.Entity<ApplicationUser>()
                .HasOne(a => a.UserDetails)
                .WithOne(u => u.ApplicationUser)
                .HasForeignKey<UserDetails>(u => u.ApplicationUserId)
                .OnDelete(DeleteBehavior.Cascade);

            // ---------------------------------------
            // UserDetails -> Teacher / Student
            // ---------------------------------------

            builder.Entity<UserDetails>()
                .HasOne(u => u.Teacher)
                .WithOne(t => t.UserDetails)
                .HasForeignKey<Teacher>(t => t.UserDetailsId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserDetails>()
                .HasOne(u => u.Student)
                .WithOne(s => s.UserDetails)
                .HasForeignKey<Student>(s => s.UserDetailsId)
                .OnDelete(DeleteBehavior.Cascade);

            // ---------------------------------------
            // Course -> Module -> Lesson
            // ---------------------------------------

            builder.Entity<Module>()
                .HasOne(m => m.Course)
                .WithMany(c => c.Modules)
                .HasForeignKey(m => m.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Lesson>()
                .HasOne(l => l.Module)
                .WithMany(m => m.Lessons)
                .HasForeignKey(l => l.ModuleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Attachment>()
                .HasOne(a => a.Lesson)
                .WithMany(l => l.Attachments)
                .HasForeignKey(a => a.LessonId)
                .OnDelete(DeleteBehavior.Cascade);

            // ---------------------------------------
            // Teacher <-> Course (CourseTeacher junction)
            // ---------------------------------------

            builder.Entity<CourseTeacher>()
                .HasIndex(ct => new { ct.CourseId, ct.TeacherId })
                .IsUnique();

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

            // ---------------------------------------
            // Student <-> Course through Enrollment
            // ---------------------------------------

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

            // ---------------------------------------
            // Enrollment -> LessonProgress
            // ---------------------------------------

            builder.Entity<LessonProgress>()
                .HasOne(lp => lp.Enrollment)
                .WithMany()
                .HasForeignKey(lp => lp.EnrollmentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<LessonProgress>()
                .HasOne(lp => lp.Lesson)
                .WithMany(l => l.LessonProgresses)
                .HasForeignKey(lp => lp.LessonId)
                .OnDelete(DeleteBehavior.NoAction);

            // ---------------------------------------
            // Course -> Assignment -> AssignmentSubmission -> Grade
            // ---------------------------------------

            builder.Entity<Assignment>()
                .HasOne(a => a.Course)
                .WithMany(c => c.Assignments)
                .HasForeignKey(a => a.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

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

            builder.Entity<Grade>()
                .HasOne(g => g.AssignmentSubmission)
                .WithOne(a => a.GradeInfo)
                .HasForeignKey<Grade>(g => g.AssignmentSubmissionId)
                .OnDelete(DeleteBehavior.Cascade);

            // ---------------------------------------
            // Course -> Quiz -> Question -> AnswerOption
            // Quiz -> QuizAttempt
            // ---------------------------------------

            builder.Entity<Quiz>()
                .HasOne(q => q.Course)
                .WithMany()
                .HasForeignKey(q => q.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Question>()
                .HasOne(q => q.Quiz)
                .WithMany(qz => qz.Questions)
                .HasForeignKey(q => q.QuizId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<AnswerOption>()
                .HasOne(o => o.Question)
                .WithMany(q => q.AnswerOptions)
                .HasForeignKey(o => o.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<QuizAttempt>()
                .HasOne(qa => qa.Quiz)
                .WithMany(q => q.QuizAttempts)
                .HasForeignKey(qa => qa.QuizId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<QuizAttempt>()
                .HasOne(qa => qa.Student)
                .WithMany()
                .HasForeignKey(qa => qa.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            // ---------------------------------------
            // Course -> CourseSession -> Attendance
            // ---------------------------------------

            builder.Entity<CourseSession>()
                .HasOne(s => s.Course)
                .WithMany(c => c.CourseSessions)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Attendance>()
                .HasOne(a => a.CourseSession)
                .WithMany(s => s.Attendances)
                .HasForeignKey(a => a.CourseSessionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Attendance>()
                .HasOne(a => a.Student)
                .WithMany(s => s.Attendances)
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Attendance>()
                .HasIndex(a => new { a.CourseSessionId, a.StudentId })
                .IsUnique();

            // ---------------------------------------
            // Course -> Announcement
            // ---------------------------------------

            builder.Entity<Announcement>()
                .HasOne(a => a.Course)
                .WithMany()
                .HasForeignKey(a => a.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}