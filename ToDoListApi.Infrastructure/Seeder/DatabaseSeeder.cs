using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApi.Domain.Entities;
using ToDoListApi.Infrastructure.Persistence;

namespace ToDoListApi.Infrastructure.Seeder
{
    public static class DatabaseSeeder
    {
        public static async Task SeedDatabaseAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ToDoListDbContext>();

            // Apply any pending migrations
            await context.Database.MigrateAsync();

            // Seed priorities if none exist
            if (!await context.Priorities.AnyAsync())
            {
                await SeedPrioritiesAsync(context);
                Console.WriteLine("Priorities seeded successfully.");
            }

            // Seed statuses if none exist
            if (!await context.Statuses.AnyAsync())
            {
                await SeedStatusesAsync(context);
                Console.WriteLine("Statuses seeded successfully.");
            }

            // Seed todo tasks if none exist
            if (!await context.ToDoTasks.AnyAsync())
            {
                // Important: Save changes after seeding priorities and statuses
                // to ensure they have IDs before referencing them in ToDoTasks
                await context.SaveChangesAsync();

                await SeedToDoTasksAsync(context);
                Console.WriteLine("ToDoTasks seeded successfully.");
            }
        }

        private static async Task SeedPrioritiesAsync(ToDoListDbContext context)
        {
            var priorities = new List<Priority>
            {
                new Priority { Name = "Low" },
                new Priority { Name = "Medium" },
                new Priority { Name = "High" },
                new Priority { Name = "Critical" }
            };

            await context.Priorities.AddRangeAsync(priorities);
            await context.SaveChangesAsync();
        }

        private static async Task SeedStatusesAsync(ToDoListDbContext context)
        {
            var statuses = new List<Status>
            {
                new Status { Name = "To Do" },
                new Status { Name = "In Progress" },
                new Status { Name = "On Hold" },
                new Status { Name = "Completed" },
                new Status { Name = "Cancelled" }
            };

            await context.Statuses.AddRangeAsync(statuses);
            await context.SaveChangesAsync();
        }

        private static async Task SeedToDoTasksAsync(ToDoListDbContext context)
        {
            // Get existing priority and status IDs
            var priorities = await context.Priorities.ToListAsync();
            var statuses = await context.Statuses.ToListAsync();

            // Make sure we have data before proceeding
            if (!priorities.Any() || !statuses.Any())
            {
                Console.WriteLine("Cannot seed ToDo tasks: Priorities or Statuses not found in database.");
                return;
            }

            var lowPriorityId = priorities.First(p => p.Name == "Low").Id;
            var mediumPriorityId = priorities.First(p => p.Name == "Medium").Id;
            var highPriorityId = priorities.First(p => p.Name == "High").Id;
            var criticalPriorityId = priorities.First(p => p.Name == "Critical").Id;

            var todoStatusId = statuses.First(s => s.Name == "To Do").Id;
            var inProgressStatusId = statuses.First(s => s.Name == "In Progress").Id;
            var onHoldStatusId = statuses.First(s => s.Name == "On Hold").Id;
            var completedStatusId = statuses.First(s => s.Name == "Completed").Id;

            var currentDate = DateTime.UtcNow;

            var todoTasks = new List<ToDoTask>
            {
                new ToDoTask
                {
                    Title = "Complete project documentation",
                    Description = "Finish writing the API documentation with examples",
                    PriorityId = highPriorityId,
                    StatusId = todoStatusId,
                    CreationDate = currentDate,
                    ModifiedDate = currentDate,
                    DueToDate = currentDate.AddDays(5)
                },
                new ToDoTask
                {
                    Title = "Fix login bug",
                    Description = "Resolve the authentication issue reported in JIRA ticket #1234",
                    PriorityId = criticalPriorityId,
                    StatusId = inProgressStatusId,
                    CreationDate = currentDate.AddDays(-2),
                    ModifiedDate = currentDate,
                    DueToDate = currentDate.AddDays(1)
                },
                new ToDoTask
                {
                    Title = "Create unit tests",
                    Description = "Write unit tests for the new TaskController methods",
                    PriorityId = mediumPriorityId,
                    StatusId = todoStatusId,
                    CreationDate = currentDate,
                    ModifiedDate = currentDate,
                    DueToDate = currentDate.AddDays(7)
                },
                new ToDoTask
                {
                    Title = "Review pull requests",
                    Description = "Review and approve team pull requests for the new feature",
                    PriorityId = mediumPriorityId,
                    StatusId = inProgressStatusId,
                    CreationDate = currentDate.AddDays(-1),
                    ModifiedDate = currentDate,
                    DueToDate = currentDate.AddDays(2)
                },
                new ToDoTask
                {
                    Title = "Database optimization",
                    Description = "Optimize database queries to improve API response time",
                    PriorityId = lowPriorityId,
                    StatusId = onHoldStatusId,
                    CreationDate = currentDate.AddDays(-5),
                    ModifiedDate = currentDate,
                    DueToDate = currentDate.AddDays(14)
                },
                new ToDoTask
                {
                    Title = "Deploy to staging",
                    Description = "Deploy the latest changes to the staging environment",
                    PriorityId = highPriorityId,
                    StatusId = completedStatusId,
                    CreationDate = currentDate.AddDays(-3),
                    ModifiedDate = currentDate.AddDays(-1),
                    DueToDate = currentDate.AddDays(-1)
                }
            };

            await context.ToDoTasks.AddRangeAsync(todoTasks);
            await context.SaveChangesAsync();
        }
    }
}