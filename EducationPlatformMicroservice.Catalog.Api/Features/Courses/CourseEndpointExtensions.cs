using EducationPlatformMicroservice.Catalog.Api.Features.Categories.Create;
using EducationPlatformMicroservice.Catalog.Api.Features.Courses.Create;
using EducationPlatformMicroservice.Catalog.Api.Features.Courses.GetAll;
using EducationPlatformMicroservice.Catalog.Api.Features.Courses.GetById;

namespace EducationPlatformMicroservice.Catalog.Api.Features.Courses
{
    public static class CourseEndpointExtensions
    {
        public static void AddCourseGroupEndpointExtensions(this WebApplication webApplication)
        {
            webApplication.MapGroup("api/courses").WithTags("Courses")
                .CreateCourseGroupItemEndpoint()
                .GetAllCourseGroupItemEndpoint()
                .GetByIdCourseGroupItemEndpoint();



        }
    }
}
