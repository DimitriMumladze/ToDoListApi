using ToDoListApi.Infrastructure.Persistence;
using ToDoListApi.Domain.Repositories;
using ToDoListApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace ToDoListApi.Infrastructure.Repositories;

internal class ToDoTasksRepository(ToDoListDbContext dbContext) : IToDoTasksRepository
{
    public Task<bool> BulkCreateToDoTasksAsync(IEnumerable<ToDoTask> toDoTasks)
    {
        throw new NotImplementedException();
    }

    public Task<ToDoTask> CreateToDoTaskAsync(ToDoTask entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ToDoTask>> GetAllToDoTasksAsync()
    {
        var tasks = await dbContext.ToDoTasks.ToListAsync();
        return tasks;
    }

    public Task<ToDoTask?> GetToDoTaskByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> SoftDeleteToDoTaskAsync(int id)
    {
        throw new NotImplementedException();
    }
}
