using EducationPlatformMicroservice.Catalog.Api.Features.Courses.Dtos;

namespace EducationPlatformMicroservice.Catalog.Api.Features.Courses.GetAll
{
    public record GetAllCoursesQuery() : IRequestByServiceResult<List<CourseDto>>;
}
