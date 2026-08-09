using FluentValidation;

namespace EducationPlatformMicroservice.Catalog.Api.Features.Courses.Create
{
    public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
    {
        public CreateCourseCommandValidator() 
        {
        
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Course name is required.")
                .MaximumLength(100).WithMessage("Course name must not exceed 100 characters.");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Course description is required.")
                .MaximumLength(1000).WithMessage("Course description must not exceed 1000 characters.");
            RuleFor(x => x.Price).Cascade(CascadeMode.Stop) // bir kural başarısız olursa diğer kuralları kontrol etme
                .NotEmpty().WithMessage("Course price is required.")
                .GreaterThan(0).WithMessage("Course price must be greater than 0.");
            RuleFor(x => x.ImageUrl).Cascade(CascadeMode.Stop)
                .Must(uri => Uri.IsWellFormedUriString(uri, UriKind.Absolute)).WithMessage("Course image URL must be a valid URL.");
            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Course category is required.");
        }
    }
}
