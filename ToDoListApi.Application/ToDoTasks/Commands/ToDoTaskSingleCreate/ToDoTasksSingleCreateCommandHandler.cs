using AutoMapper;
using MediatR;
using ToDoListApi.Application.ToDoTasks.Dtos;
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
        
    }
}
