using ToDoListApi.Infrastructure.Persistence;
using ToDoListApi.Domain.Repositories;
using ToDoListApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ToDoListApi.Application.ToDoTasks.Dtos;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;
namespace ToDoListApi.Infrastructure.Repositories;

internal class ToDoTasksRepository(ToDoListDbContext dbContext) : IToDoTasksRepository
{
    public Task<bool> BulkCreateToDoTasksAsync(IEnumerable<ToDoTask> toDoTasks)
    {
        throw new NotImplementedException();
    }

    public async Task<ToDoTask> CreateToDoTaskAsync(ToDoTaskDto toDoTaskDto)
    {
        var toDoTask = new ToDoTask
        {
            Title = toDoTaskDto.Title,
            Description = toDoTaskDto.Description,
            DueToDate = toDoTaskDto.DueToDate,
            CreationDate = DateTime.UtcNow, 
        };

        dbContext.ToDoTasks.Add(toDoTask);
        await dbContext.SaveChangesAsync(); 
        return toDoTask;
    }

    public Task<ToDoTask> CreateToDoTaskAsync(ToDoTask entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ToDoTask>> GetAllToDoTasksAsync()
    {
        var tasks = await dbContext.ToDoTasks
        .Include(t => t.Priority)
        .Include(t => t.Status)
        .ToListAsync();

        return tasks;
    }

    public async Task<ToDoTask?> GetToDoTaskByIdAsync(int id)
    {
        var task = await dbContext.ToDoTasks
        .Include(t => t.Priority)
        .Include(t => t.Status)
        .FirstOrDefaultAsync(t => t.Id == id);

        return task;
    }

    public Task<bool> SoftDeleteToDoTaskAsync(int id)
    {
        throw new NotImplementedException();
    }
}
