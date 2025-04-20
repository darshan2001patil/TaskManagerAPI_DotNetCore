using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TaskManager.Api.Models;

namespace TaskManager.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<TaskItem> Tasks => Set<TaskItem>();
        public DbSet<User> Users => Set<User>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", Password = "admin123", Role = "Admin" },
                new User { Id = 2, Username = "user1", Password = "user123", Role = "User" },
                new User { Id = 3, Username = "user2", Password = "user123", Role = "User" }
            );

            modelBuilder.Entity<TaskItem>().HasData(
                new TaskItem { Id = 1, Title = "Setup project", Description = "Create base app", DueDate = DateTime.UtcNow.AddDays(5), IsCompleted = false, AssignedTo = "user1",CreatedBy = "admin" },
                new TaskItem { Id = 2, Title = "Fix bugs", Description = "Resolve login issue", DueDate = DateTime.UtcNow.AddDays(6), IsCompleted = false, AssignedTo = "user2", CreatedBy = "admin" },
                new TaskItem { Id = 3, Title = "Review PR", Description = "Review latest PR", DueDate = DateTime.UtcNow.AddDays(10), IsCompleted = false, AssignedTo = "admin", CreatedBy = "admin" }
            );
        }

    }
}