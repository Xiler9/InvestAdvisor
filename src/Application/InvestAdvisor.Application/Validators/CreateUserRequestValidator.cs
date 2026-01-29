using FluentValidation;
using InvestAdvisor.Application.DTOs;

namespace InvestAdvisor.Application.Validators
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(x => x.NickName)
                .NotNull()
                .WithMessage("Nickname не может быть пустым")
                .NotEmpty()
                .WithMessage("Nickname не может быть пустым")
                .Must(x => x.Length <= 50)
                .WithMessage("Длина NickName не должна превышать 50");

            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage("Email не может быть пустым")
                .NotEmpty()
                .WithMessage("Email не может быть пустым")
                .Must(x => x.Contains('.'))
                .WithMessage("Почта должна содержать .")
                .Must(x => x.Contains('@'))
                .WithMessage("Почта должна содержать @");
        }
    }
}