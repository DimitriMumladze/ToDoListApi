using AutoMapper;
using MediatR;
using ToDoListApi.Domain.Entities;
using ToDoListApi.Domain.Exceptions;
using ToDoListApi.Domain.Repositories;

namespace ToDoListApi.Application.ToDoTasks.Queries.GetByIdToDoTasks;

public class GetByIdToDoTasksQueryHandler : IRequestHandler<GetByIdToDoTasksQuery, ToDoTaskDto?>
{
    private readonly IMapper _mapper;
    private readonly IToDoTasksRepository _toDoTaskRepository;

    public GetByIdToDoTasksQueryHandler(IMapper mapper, IToDoTasksRepository toDoTaskRepository)
    {
        _mapper = mapper;
        _toDoTaskRepository = toDoTaskRepository;
    }
    public async Task<ToDoTaskDto?> Handle(GetByIdToDoTasksQuery request, CancellationToken cancellationToken)
    {
        var toDoTaskById = await _toDoTaskRepository.GetToDoTaskByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(ToDoTask), request.Id.ToString());

        var toDoTaskByIdDto = _mapper.Map<ToDoTaskDto>(toDoTaskById);

        return toDoTaskByIdDto;
    }
}
