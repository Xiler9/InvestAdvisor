using FluentValidation;
using InvestAdvisor.Api.DTOs.Requests;

namespace InvestAdvisor.Application.Validators
{
    public class CreateNoteRequestValidator : AbstractValidator<CreateNoteRequest>
    {
        public CreateNoteRequestValidator()
        {
            RuleFor(x => x.UserId)
                .NotNull()
                .WithMessage("UserId не может быть null")
                .Must(x => x > 0)
                .WithMessage("UserId должен быть больше нуля");

            RuleFor(x => x.Title)
                .NotNull()
                .WithMessage("Title не может быть null")
                .Must(x => x.Length <= 100)
                .WithMessage("Длина Title не может превышать 100");

            RuleFor(x => x.Text)
                .NotNull()
                .WithMessage("Text  не может быть null")
                .Must(x => x.Length <= 1000)
                .WithMessage("Длина Title не может превышать 1000");
        }
    }
}