using ToDoListApi.Domain.Entities;

namespace ToDoListApi.Domain.Repositories;

public interface IToDoTasksRepository
{
    Task<ICollection<ToDoTask>> GetAllToDoTasksAsync();
    Task<ToDoTask?> GetToDoTaskByIdAsync(int id);
    Task<bool> BulkCreateToDoTasksAsync(ICollection<ToDoTask> entity);
    Task<int> CreateToDoTaskAsync(ToDoTask? entity);
    Task<bool> SoftDeleteToDoTaskAsync(int id);
}
