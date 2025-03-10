using ToDoListApi.Domain.Entities;

namespace ToDoListApi.Domain.Repositories;

public interface IToDoTasksRepository
{
    Task<IEnumerable<ToDoTask>> GetAllToDoTasksAsync();
    Task<ToDoTask?> GetToDoTaskByIdAsync(int id);
    Task<bool> BulkCreateToDoTasksAsync(IEnumerable<ToDoTask> entity);
    Task<int> CreateToDoTaskAsync(ToDoTask? entity);
    Task<bool> SoftDeleteToDoTaskAsync(int id);
}
