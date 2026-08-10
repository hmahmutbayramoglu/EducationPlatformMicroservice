using EducationPlatformMicroservice.Catalog.Api.Features.Courses.Dtos;

namespace EducationPlatformMicroservice.Catalog.Api.Features.Courses.GetById
{
    public record GetCourseByIdQuery(Guid Id) : IRequestByServiceResult<CourseDto>;
}
