using AutoMapper;
using ToDoListApi.Application.ToDoTasks.Commands.ToDoTaskSingleCreate;
using ToDoListApi.Application.ToDoTasks.Dtos;
using ToDoListApi.Domain.Entities;

namespace ToDoListApi.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ToDoTask, ToDoTaskDto>().ReverseMap();
        CreateMap<Priority, PriorityDto>().ReverseMap();
        CreateMap<Status, StatusDto>().ReverseMap();
    }
}
