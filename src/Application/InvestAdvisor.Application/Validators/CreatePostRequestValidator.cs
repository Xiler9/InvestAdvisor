using FluentValidation;
using InvestAdvisor.Api.DTOs.Requests;
using InvestAdvisor.Application.Interfaces.Repositories;
using InvestAdvisor.Domain.Models;

namespace InvestAdvisor.Application.Validators
{
    public class CreatePostRequestValidator : AbstractValidator<CreatePostRequest>
    {
        private readonly IPostRepositorie _postRepositorie;

        public CreatePostRequestValidator(IPostRepositorie postRepositorie)
        {
            _postRepositorie = postRepositorie;

            RuleFor(x => x.UserId)
                .Must(x => x > 0)
                .WithMessage("UserId должен быть больше нуля")
                .MustAsync(async (x, cancellToken) =>
                {
                    List<Post> posts = await _postRepositorie.GetAllPostsAsync();
                    return !posts.Any(post => post.Id == x);
                })
                .WithMessage("Пост с таким Id уже существует");

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