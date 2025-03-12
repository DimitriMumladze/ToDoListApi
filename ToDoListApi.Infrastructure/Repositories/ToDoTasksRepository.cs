using ToDoListApi.Infrastructure.Persistence;
using ToDoListApi.Domain.Repositories;
using ToDoListApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ToDoListApi.Infrastructure.Repositories;

internal class ToDoTasksRepository(ToDoListDbContext dbContext) : IToDoTasksRepository
{
    public async Task<int> CreateToDoTaskAsync(ToDoTask? entity)
    {
        dbContext.ToDoTasks.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task DeleteToDoTaskAsync(ToDoTask? entity)
    {
        //Error
        var toDoTask = await GetToDoTaskByIdAsync(entity.Id);

        dbContext.ToDoTasks.Remove(toDoTask);
        await dbContext.SaveChangesAsync();
    }

    public async Task<ICollection<ToDoTask>> GetAllToDoTasksAsync()
    {
        var tasks = await dbContext.ToDoTasks
        .Include(t => t.Priority)
        .Include(t => t.Status)
        .ToListAsync();

        return tasks;
    }

    public async Task<ToDoTask?>? GetToDoTaskByIdAsync(int id)
    {
        var task = await dbContext.ToDoTasks
        .Include(t => t.Priority)
        .Include(t => t.Status)
        .FirstOrDefaultAsync(t => t.Id == id);
        return task;
    }
}
