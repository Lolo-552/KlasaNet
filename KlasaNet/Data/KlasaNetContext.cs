using KlasaNet.Models;
using Microsoft.EntityFrameworkCore;

namespace KlasaNet.Data
{
    public class KlasaNetContext : DbContext
    {
        public KlasaNetContext(DbContextOptions<KlasaNetContext> options) : base(options)
        {
        }

        public DbSet<School> Schools { get; set; } = null!;
        public DbSet<Director> Directors { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Class> Classes { get; set; } = null!;
        public DbSet<Teacher> Teachers { get; set; } = null!;
        public DbSet<Subject> Subjects { get; set; } = null!;
        public DbSet<TeacherSubjectClass> TeacherSubjectClasses { get; set; } = null!;
        public DbSet<Parent> Parents { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasOne(s => s.Class)
                      .WithMany(c => c.Students)
                      .HasForeignKey(s => s.IdClass);

                entity.HasOne(s => s.School)
                      .WithMany(s => s.Students)
                      .HasForeignKey(s => s.IdSchool);

                entity.HasOne(s => s.HomeroomTeacher)
                      .WithMany(t => t.Students)
                      .HasForeignKey(s => s.IdHomeroomTeacher)
                      .OnDelete(DeleteBehavior.NoAction);

                entity.HasMany(s => s.Parents)
                      .WithMany(p => p.Students)
                      .UsingEntity(j => j.ToTable("StudentParent"));
            });

            modelBuilder.Entity<TeacherSubjectClass>(entity =>
            {
                entity.HasKey(tsc => new { tsc.IdTeacher, tsc.IdClass, tsc.IdSubject });

                entity.HasOne(tsc => tsc.Teacher)
                      .WithMany(t => t.TeacherSubjectClasses)
                      .HasForeignKey(tsc => tsc.IdTeacher)
                      .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(tsc => tsc.Class)
                      .WithMany(c => c.TeacherSubjectClasses)
                      .HasForeignKey(tsc => tsc.IdClass)
                      .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(tsc => tsc.Subject)
                      .WithMany(s => s.TeacherSubjectClasses)
                      .HasForeignKey(tsc => tsc.IdSubject)
                      .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(tsc => tsc.School)
                      .WithMany(s => s.TeacherSubjectClasses)
                      .HasForeignKey(tsc => tsc.IdSchool)
                      .OnDelete(DeleteBehavior.NoAction);
            });


            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasOne(t => t.School)
                      .WithMany(s => s.Teachers)
                      .HasForeignKey(t => t.IdSchool);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasOne(s => s.School)
                      .WithMany(s => s.Subjects)
                      .HasForeignKey(s => s.IdSchool);
            });

            modelBuilder.Entity<Director>(entity =>
            {
                entity.HasOne(d => d.School)
                      .WithMany(s => s.Directors)
                      .HasForeignKey(d => d.IdSchool);
            });

            modelBuilder.Entity<Parent>(entity =>
            {
                entity.HasMany(p => p.Students)
                      .WithMany(s => s.Parents)
                      .UsingEntity(j => j.ToTable("StudentParent"));
            });
        }
    }
}
