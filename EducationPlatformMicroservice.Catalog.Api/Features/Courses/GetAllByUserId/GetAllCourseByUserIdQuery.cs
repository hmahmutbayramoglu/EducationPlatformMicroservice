using EducationPlatformMicroservice.Catalog.Api.Features.Courses.Dtos;

namespace EducationPlatformMicroservice.Catalog.Api.Features.Courses.GetAllByUserId
{
    public record GetAllCourseByUserIdQuery(Guid Id) : IRequestByServiceResult<List<CourseDto>>;


}
