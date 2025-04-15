using System;
using System.Reflection.Metadata;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.EntityFramework
{
    /// <summary>
    /// Контекст.
    /// </summary>
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        
        /// <summary>
        /// Процессы поиска
        /// </summary>
        public DbSet<SonarProcess> SonarProcess { get; set; }
        
        /// <summary>
        /// Задачи поиска
        /// </summary>
        public DbSet<SonarTask> SonarTasks { get; set; }

        /// <summary>
        /// Группы поиска
        /// </summary>
        public DbSet<SearchGroup> SearchGroups { get; set; }

        /// <summary>
        /// Участники группы поиска
        /// </summary>
        public DbSet<GroupMember> GroupMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);            
            
            modelBuilder.Entity<SonarProcess>()
                .HasMany(u => u.SonarTasks)
                .WithOne(c=> c.SonarProcess)
                .IsRequired();
            
        //    modelBuilder.Entity<>()
        //.Property(d => d.Created)
        //.HasDefaultValueSql("CURRENT_TIMESTAMP");

            //modelBuilder.Entity<SearchGroup>()
            //    .Property(d => d.UpdatedAt)
            //    .HasDefaultValueSql("CURRENT_TIMESTAMP")
            //    .ValueGeneratedOnUpdate(); // PostgreSQL поддерживает это через триггеры

            modelBuilder.Entity<SearchGroup>()
                .HasMany(u => u.Members)
                .WithOne(c => c.Group)
                .IsRequired();


            //modelBuilder.Entity<Course>().HasIndex(c=>c.Name);

            modelBuilder.Entity<SonarProcess>().Property(c => c.Name).HasMaxLength(100);
            modelBuilder.Entity<SonarTask>().Property(c => c.Subject).HasMaxLength(100);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);   
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries();

            foreach (var entry in entries)
            {
                if (entry.Entity is SearchGroup group)
                {
                    var now = DateTime.UtcNow;

                    if (entry.State == EntityState.Added)
                    {
                        // Установка времени создания при добавлении новой записи
                        group.CreatedAt = now;
                    }

                    if (entry.State == EntityState.Modified)
                    {
                        // Обновление времени изменения при изменении записи
                        group.UpdatedAt = now;
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}