using FluentValidation;

namespace ToDoListApi.Application.ToDoTasks.Commands.ToDoTaskSingleCreate;

public class ToDoTaskSingleCreateCommandValidator : AbstractValidator<ToDoTasksSingleCreateCommand>
{
    public ToDoTaskSingleCreateCommandValidator()
    {
        RuleFor(dto => dto.Title)
            .NotEmpty()
            .WithMessage("Please insert title");

        RuleFor(dto => dto.Description)
            .NotEmpty()
            .WithMessage("Please insert description");

        RuleFor(dto => dto.PriorityId)
            .NotEmpty()
            .WithMessage("Please insert Id for priority");

        RuleFor(dto => dto.StatusId)
            .NotEmpty()
            .WithMessage("Please insert Id for status");

        RuleFor(dto => dto.DueToDate)
            .NotEmpty()
            .WithMessage("Please insert due date");
    }
}
