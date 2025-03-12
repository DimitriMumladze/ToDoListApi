using Microsoft.EntityFrameworkCore;
using ToDoListApi.Domain.Entities;

namespace ToDoListApi.Infrastructure.Persistence;

internal class ToDoListDbContext(DbContextOptions<ToDoListDbContext> options) : DbContext(options)
{
    internal DbSet<Priority> Priorities { get; set; }
    internal DbSet<Status> Statuses { get; set; }
    internal DbSet<ToDoTask> ToDoTasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ToDoTask>()
            .HasOne(t => t.Status)
            .WithMany(s => s.ToDoTasks)
            .HasForeignKey(t => t.StatusId);

        modelBuilder.Entity<ToDoTask>()
            .HasOne(p => p.Priority)
            .WithMany(s => s.ToDoTasks)
            .HasForeignKey(p => p.PriorityId);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<ToDoTask>())
        {
            if (entry.State == EntityState.Modified)
            {
                entry.Entity.ModifiedDate = DateTime.UtcNow;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

}
