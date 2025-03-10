using ToDoListApi.Infrastructure.Persistence;
using ToDoListApi.Domain.Repositories;
using ToDoListApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ToDoListApi.Application.ToDoTasks.Dtos;
namespace ToDoListApi.Infrastructure.Repositories;

internal class ToDoTasksRepository(ToDoListDbContext dbContext) : IToDoTasksRepository
{
    public Task<bool> BulkCreateToDoTasksAsync(IEnumerable<ToDoTask> toDoTasks)
    {
        throw new NotImplementedException();
    }
    private ToDoTask ConvertDtoToEntity(ToDoTaskDto toDoTaskDto)
    {
        return new ToDoTask
        {
            Title = toDoTaskDto.Title,
            Description = toDoTaskDto.Description ?? "",
            DueToDate = toDoTaskDto.DueToDate,
            CreationDate = DateTime.UtcNow,
        };
    }
    public async Task<ToDoTask?> CreateToDoTaskAsync(ToDoTask toDoTask)
    {
        dbContext.ToDoTasks.Add(toDoTask);
        await dbContext.SaveChangesAsync();
        return toDoTask;
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
