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
        /// Пользователи
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Питомцы
        /// </summary>
        public DbSet<Animal> Animals { get; set; }

        /// <summary>
        /// Обьявления о пропаже животных
        /// </summary>
        public DbSet<SearchAnnouncement> SearchAnnouncements { get; set; }

        /// <summary>
        /// Зарегестированные запросы поиска животных
        /// </summary>
        /// <remarks>Зарегестированный запро это уже действие на появление обьявления о поиске животных его заводит координатор </remarks>
        public DbSet<SearchRequest> SearchRequests { get; set; }

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


            // Animal → User (OwnerId)
            modelBuilder.Entity<Animal>()
                .HasOne(a => a.Owner)
                .WithMany(u => u.Animals)
                .HasForeignKey(a => a.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            // SearchAnnouncement → Animal (AnimalId)
            modelBuilder.Entity<SearchAnnouncement>()
                .HasOne(sa => sa.Animal)
                .WithMany(a => a.SearchAnnouncements)
                .HasForeignKey(sa => sa.AnimalId)
                .OnDelete(DeleteBehavior.Cascade);

            // SearchAnnouncement → User (OwnerId)
            modelBuilder.Entity<SearchAnnouncement>()
                .HasOne(sa => sa.Owner)
                .WithMany(u => u.SearchAnnouncements)
                .HasForeignKey(sa => sa.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            // SearchRequest → SearchAnnouncement (AnnouncementId)
            modelBuilder.Entity<SearchRequest>()
                .HasOne(sr => sr.Announcement)
                .WithMany(sa => sa.SearchRequests)
                .HasForeignKey(sr => sr.AnnouncementId)
                .OnDelete(DeleteBehavior.Cascade);

            // SearchRequest → User (CoordinatorId)
            modelBuilder.Entity<SearchRequest>()
                .HasOne(sr => sr.Coordinator)
                .WithMany(u => u.CoordinatedRequests)
                .HasForeignKey(sr => sr.CoordinatorId)
                .OnDelete(DeleteBehavior.Restrict);

            // SearchGroup → SearchRequest (RequestId)
            modelBuilder.Entity<SearchGroup>()
                .HasOne(sg => sg.Request)
                .WithMany(sr => sr.Groups)
                .HasForeignKey(sg => sg.RequestId)
                .OnDelete(DeleteBehavior.Cascade);

            // SearchGroup → User (LeaderId)
            modelBuilder.Entity<SearchGroup>()
                .HasOne(sg => sg.Leader)
                .WithMany(u => u.LedGroups)
                .HasForeignKey(sg => sg.LeaderId)
                .OnDelete(DeleteBehavior.Restrict);

            // GroupMember → SearchGroup (GroupId)
            modelBuilder.Entity<GroupMember>()
                .HasOne(gm => gm.Group)
                .WithMany(sg => sg.Members)
                .HasForeignKey(gm => gm.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

            // GroupMember → User (UserId)
            modelBuilder.Entity<GroupMember>()
                .HasOne(gm => gm.User)
                .WithMany(u => u.GroupMemberships)
                .HasForeignKey(gm => gm.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // SearchEvent → SearchRequest (RequestId)
            modelBuilder.Entity<SearchEvent>()
                .HasOne(se => se.Request)
                .WithMany(sr => sr.Events)
                .HasForeignKey(se => se.RequestId)
                .OnDelete(DeleteBehavior.Cascade);

            // SearchEvent → User (CreatedBy)
            modelBuilder.Entity<SearchEvent>()
                .HasOne(se => se.Creator)
                .WithMany(u => u.CreatedEvents)
                .HasForeignKey(se => se.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            // SearchTask → SearchEvent (EventId)
            modelBuilder.Entity<SearchTask>()
                .HasOne(st => st.Event)
                .WithMany(se => se.Tasks)
                .HasForeignKey(st => st.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            // SearchTask → User (AssignedToId)
            modelBuilder.Entity<SearchTask>()
                .HasOne(st => st.AssignedTo)
                .WithMany(u => u.AssignedTasks)
                .HasForeignKey(st => st.AssignedToId)
                .OnDelete(DeleteBehavior.Restrict);

            // VDV: Прошлое удалить после стабилизации

            //modelBuilder.Entity<SearchTask>(entity =>
            //{
            //    entity.HasOne(t => t.Event)
            //          .WithMany(e => e.Tasks)
            //          .HasForeignKey(t => t.EventId)
            //          //.OnDelete(DeleteBehavior.Restrict)
            //          ; // или Cascade, если нужно
            //});


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

            //modelBuilder.Entity<SearchGroup>()
            //    .HasMany(u => u.Members)
            //    .WithOne(c => c.Group)
            //    .IsRequired();


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