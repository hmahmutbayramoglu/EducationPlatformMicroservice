namespace EducationPlatformMicroservice.Catalog.Api.Features.Courses.Delete
{
    public record DeleteCourseCommand(Guid CourseId) : IRequestByServiceResult;
}
