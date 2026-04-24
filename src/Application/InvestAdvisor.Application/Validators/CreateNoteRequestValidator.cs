using FluentValidation;
using InvestAdvisor.Api.DTOs.Requests;

namespace InvestAdvisor.Application.Validators
{
    public class CreateNoteRequestValidator : AbstractValidator<CreateNoteRequest>
    {
        public CreateNoteRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .WithMessage("Title не может быть null")
                .Must(x => x.Length <= 100)
                .WithMessage("Длина Title не может превышать 100");

            RuleFor(x => x.Text)
                .NotNull()
                .WithMessage("Description  не может быть null")
                .Must(x => x.Length <= 1000)
                .WithMessage("Длина Title не может превышать 1000");

            RuleFor(x => x.Category)
                .NotNull()
                .WithMessage("Category  не может быть null");
        }
    }
}