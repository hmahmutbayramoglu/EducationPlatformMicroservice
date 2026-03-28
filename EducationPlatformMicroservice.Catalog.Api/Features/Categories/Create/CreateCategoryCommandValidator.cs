using FluentValidation;

namespace EducationPlatformMicroservice.Catalog.Api.Features.Categories.Create
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .Length(4, 50).WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters.");
        }
        
    }
}
