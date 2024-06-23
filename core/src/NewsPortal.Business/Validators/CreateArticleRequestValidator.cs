using FluentValidation;
using NewsPortal.Business.Models;

namespace NewsPortal.Business.Validators
{
    public class CreateArticleRequestValidator : AbstractValidator<CreateArticleRequest>
    {
        public CreateArticleRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title cannot be empty")
                .MaximumLength(250)
                .WithMessage("Title length cannot exceed 250 characters");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description cannot be empty");

            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .WithMessage("Category cannot be empty or 0");

        }
    }
}
