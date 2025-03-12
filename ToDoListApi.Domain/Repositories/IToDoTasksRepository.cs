using ToDoListApi.Application.ToDoTasks.Dtos;
using ToDoListApi.Domain.Entities;

namespace ToDoListApi.Domain.Repositories;

public interface IToDoTasksRepository
{
    Task<ICollection<ToDoTaskDto>> GetAllToDoTasksAsync();
    Task<ToDoTask?> GetToDoTaskByIdAsync(int id);
    Task<bool> BulkCreateToDoTasksAsync(ICollection<ToDoTaskDto> entity);
    Task<int> CreateToDoTaskAsync(ToDoTaskDto? entity);
    Task<bool> SoftDeleteToDoTaskAsync(int id);
}
