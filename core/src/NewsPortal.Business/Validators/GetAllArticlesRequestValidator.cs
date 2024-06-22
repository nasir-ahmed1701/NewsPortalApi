using FluentValidation;
using NewsPortal.Business.Models;

namespace NewsPortal.Business.Validators
{
    public class GetAllArticlesRequestValidator : AbstractValidator<GetAllArticlesRequest>
    {
        public GetAllArticlesRequestValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThan(0)
                .WithMessage("PageNumber must be greater than 0");

            RuleFor(x => x.PageSize)
                .GreaterThan(0)
                .WithMessage("PageSize must be greater than 0");
        }
    }
}
