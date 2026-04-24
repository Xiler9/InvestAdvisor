using FluentValidation;
using InvestAdvisor.Application.DTOs;

namespace InvestAdvisor.Application.Validators
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(x => x.Login)
                .NotNull()
                .WithMessage("Login не может быть пустым")
                .NotEmpty()
                .WithMessage("Login не может быть пустым")
                .Must(x => x.Length <= 50)
                .WithMessage("Длина Login не должна превышать 50");

            RuleFor(x => x.Password)
                .NotNull()
                .WithMessage("Password не может быть пустым")
                .NotEmpty()
                .WithMessage("Password не может быть пустым")
                .Must(x => x.Length <= 50)
                .WithMessage("Длина Password не должна превышать 50")
                .Must(x => x.Length >= 8)
                .WithMessage("Длина Password должна быть больше 8");

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("Title не может быть пустым")
                .NotEmpty()
                .WithMessage("Title не может быть пустым")
                .Must(x => x.Length <= 50)
                .WithMessage("Длина Title не должна превышать 50");

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