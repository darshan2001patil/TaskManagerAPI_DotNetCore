using FluentValidation;
using TaskManager.Api.DTOs;

namespace TaskManager.Api.Validators
{
    public class TaskDtoValidator : AbstractValidator<TaskDto>
    {
        public TaskDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.DueDate).GreaterThanOrEqualTo(DateTime.Today);
            RuleFor(x => x.AssignedTo).NotEmpty();
        }
    }
}