using Microsoft.EntityFrameworkCore;
using DotNETInternshipTasksApp.Task07_EntityFramework.Models;

namespace DotNETInternshipTasksApp.Task07_EntityFramework
{
    public class AppDbContext : DbContext
    {
        public DbSet<Teacher> Teachers => Set<Teacher>();
        public DbSet<Pupil> Pupils => Set<Pupil>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=school.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Pupils)
                .WithMany(p => p.Teachers)
                .UsingEntity(j => j.ToTable("TeacherPupil"));
        }
    }
}
