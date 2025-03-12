using AutoMapper;
using MediatR;
using ToDoListApi.Domain.Entities;
using ToDoListApi.Domain.Repositories;

namespace ToDoListApi.Application.ToDoTasks.Commands.ToDoTaskSingleCreate;

public class ToDoTasksSingleCreateCommandHandler : IRequestHandler<ToDoTasksSingleCreateCommand, int>
{
  
    private readonly IToDoTasksRepository _toDoTaskRepository;

    public ToDoTasksSingleCreateCommandHandler(IToDoTasksRepository toDoTaskRepository)
    {
        _toDoTaskRepository = toDoTaskRepository;
    }

    public async Task<int> Handle(ToDoTasksSingleCreateCommand request, CancellationToken cancellationToken)
    {
        var toDoItem = new ToDoTask
        {
            Id = request.Id,
            Description = request.Description,
            DueToDate = request.DueToDate,
            Title = request.Title,
            PriorityId = request.PriorityId,
            StatusId = request.StatusId,
            CreationDate = request.CreationDate,
            ModifiedDate = request.ModifiedDate
        };

        return await _toDoTaskRepository.CreateToDoTaskAsync(toDoItem);
    }
}
