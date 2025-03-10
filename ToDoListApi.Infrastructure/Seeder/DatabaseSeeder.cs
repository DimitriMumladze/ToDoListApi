using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
            }

            // Seed statuses if none exist
            if (!await context.Statuses.AnyAsync())
            {
                await SeedStatusesAsync(context);
            }

            // Seed todo tasks if none exist
            if (!await context.ToDoTasks.AnyAsync())
            {
                await SeedToDoTasksAsync(context);
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
            var priorities = await context.Priorities.ToListAsync();
            var statuses = await context.Statuses.ToListAsync();

            var currentDate = DateTime.UtcNow;

            var todoTasks = new List<ToDoTask>
            {
                new ToDoTask
                {
                    Title = "Complete project documentation",
                    Description = "Finish writing the API documentation with examples",
                    PriorityId = priorities.First(p => p.Name == "High").Id,
                    StatusId = statuses.First(s => s.Name == "To Do").Id,
                    CreationDate = currentDate,
                    ModifiedDate = currentDate,
                    DueToDate = currentDate.AddDays(5)
                },
                new ToDoTask
                {
                    Title = "Fix login bug",
                    Description = "Resolve the authentication issue reported in JIRA ticket #1234",
                    PriorityId = priorities.First(p => p.Name == "Critical").Id,
                    StatusId = statuses.First(s => s.Name == "In Progress").Id,
                    CreationDate = currentDate.AddDays(-2),
                    ModifiedDate = currentDate,
                    DueToDate = currentDate.AddDays(1)
                },
                new ToDoTask
                {
                    Title = "Create unit tests",
                    Description = "Write unit tests for the new TaskController methods",
                    PriorityId = priorities.First(p => p.Name == "Medium").Id,
                    StatusId = statuses.First(s => s.Name == "To Do").Id,
                    CreationDate = currentDate,
                    ModifiedDate = currentDate,
                    DueToDate = currentDate.AddDays(7)
                },
                new ToDoTask
                {
                    Title = "Review pull requests",
                    Description = "Review and approve team pull requests for the new feature",
                    PriorityId = priorities.First(p => p.Name == "Medium").Id,
                    StatusId = statuses.First(s => s.Name == "In Progress").Id,
                    CreationDate = currentDate.AddDays(-1),
                    ModifiedDate = currentDate,
                    DueToDate = currentDate.AddDays(2)
                },
                new ToDoTask
                {
                    Title = "Database optimization",
                    Description = "Optimize database queries to improve API response time",
                    PriorityId = priorities.First(p => p.Name == "Low").Id,
                    StatusId = statuses.First(s => s.Name == "On Hold").Id,
                    CreationDate = currentDate.AddDays(-5),
                    ModifiedDate = currentDate,
                    DueToDate = currentDate.AddDays(14)
                },
                new ToDoTask
                {
                    Title = "Deploy to staging",
                    Description = "Deploy the latest changes to the staging environment",
                    PriorityId = priorities.First(p => p.Name == "High").Id,
                    StatusId = statuses.First(s => s.Name == "Completed").Id,
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

