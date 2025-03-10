using AutoMapper;
using MediatR;
using ToDoListApi.Application.ToDoTasks.Dtos;
using ToDoListApi.Domain.Entities;
using ToDoListApi.Domain.Repositories;

namespace ToDoListApi.Application.ToDoTasks.Commands.ToDoTaskSingleCreate;

public class ToDoTasksSingleCreateCommandHandler : IRequestHandler<ToDoTasksSingleCreateCommand, int >
{
  
    private readonly IMapper _mapper;
    private readonly IToDoTasksRepository _toDoTaskRepository;

    public ToDoTasksSingleCreateCommandHandler(IMapper mapper, IToDoTasksRepository toDoTaskRepository)
    {
        _mapper = mapper;
        _toDoTaskRepository = toDoTaskRepository;
    }

    public async Task<int> Handle(ToDoTasksSingleCreateCommand request, CancellationToken cancellationToken)
    {
        request = new ToDoTasksSingleCreateCommand
        {
            Id = request.Id,
            Title = request.Title,
            Description = request.Description,
            PriorityId = request.PriorityId,
            StatusId = request.StatusId,
            CreationDate = request.CreationDate,
            DueToDate = request.DueToDate,
            ModifiedDate = request.ModifiedDate
        };

        var toDoTask = _mapper.Map<ToDoTask>(request);
        int id = await _toDoTaskRepository.CreateToDoTaskAsync(toDoTask);

        return id;
    }
}
