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
    // gadamapva minda amaze ro createis dros wamoigos kaata kvelaferi mtliani ogond using dto
    public async Task<ToDoTask> CreateToDoTaskAsync(ToDoTask entity)
    {
        var toDoTask = new ToDoTask
        {
            Title = ToDoTaskDto.Title,
            Description = toDoTaskDto.Description,
            PriorityId = toDoTaskDto.PriorityId,
            StatusId = toDoTaskDto.StatusId,
            DueToDate = toDoTaskDto.DueToDate,
            CreationDate = DateTime.UtcNow,
            ModifiedDate = DateTime.UtcNow
        };
        dbContext.ToDoTasks.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity;
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
