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
        /// Мероприятия поиска
        /// </summary>
        public DbSet<SearchEvent> SearchEvents { get; set; }
        
        /// <summary>
        /// Задачи поиска
        /// </summary>
        public DbSet<SearchTask> SearchTasks { get; set; }

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

            // VDV: Описать модель сущностей 

            modelBuilder.Entity<SearchTask>(entity =>
            {
                entity.HasOne(t => t.Event)
                      .WithMany(e => e.Tasks)
                      .HasForeignKey(t => t.EventId)
                      //.OnDelete(DeleteBehavior.Restrict)
                      ; // или Cascade, если нужно
            });


            //modelBuilder.Entity<SearchEvent>()
            //    .HasMany(u => u.SearchTasks)
            //    .WithOne(c=> c.Event)
            //    .IsRequired();

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

            //modelBuilder.Entity<SearchEvent>().Property(c => c.Status).HasMaxLength(100);
            //modelBuilder.Entity<SearchTask>().Property(c => c.Subject).HasMaxLength(100);
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
                // VDV: сделать тоже самое для остальных обьектов 
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