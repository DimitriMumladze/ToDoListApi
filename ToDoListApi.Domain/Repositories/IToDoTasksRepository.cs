using ToDoListApi.Domain.Entities;

namespace ToDoListApi.Domain.Repositories;

public interface IToDoTasksRepository
{
    Task<ICollection<ToDoTask>> GetAllToDoTasksAsync();
    Task<ToDoTask?> GetToDoTaskByIdAsync(int id);
    Task<int> CreateToDoTaskAsync(ToDoTask? entity);
    Task DeleteToDoTaskAsync(ToDoTask? entity);
}
