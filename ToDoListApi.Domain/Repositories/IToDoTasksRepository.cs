using ToDoListApi.Domain.Entities;

namespace ToDoListApi.Domain.Repositories;

public interface IToDoTasksRepository
{
    Task<IEnumerable<ToDoTask>> GetAllToDoTasksAsync();
    Task<ToDoTask?> GetToDoTaskByIdAsync(int id);
    Task<bool> BulkCreateToDoTasksAsync(IEnumerable<ToDoTask> toDoTasks);
    Task<ToDoTask?> CreateToDoTaskAsync(ToDoTask? toDoTask);
    Task<bool> SoftDeleteToDoTaskAsync(int id);
}
