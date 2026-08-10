using FluentValidation;

namespace EducationPlatformMicroservice.Catalog.Api.Features.Courses.Update
{
    public class UpdateCourseCommandValidator : AbstractValidator<UpdateCourseCommand>
    {
        public UpdateCourseCommandValidator() {

            RuleFor(x => x.Name).NotEmpty().WithMessage("Course name is required.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Course description is required.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Course price must be greater than zero.");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Category ID is required.");

        }
    }
}
