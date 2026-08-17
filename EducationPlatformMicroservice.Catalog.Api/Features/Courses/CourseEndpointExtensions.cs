using Asp.Versioning.Builder;
using EducationPlatformMicroservice.Catalog.Api.Features.Categories.Create;
using EducationPlatformMicroservice.Catalog.Api.Features.Courses.Create;
using EducationPlatformMicroservice.Catalog.Api.Features.Courses.Delete;
using EducationPlatformMicroservice.Catalog.Api.Features.Courses.GetAll;
using EducationPlatformMicroservice.Catalog.Api.Features.Courses.GetAllByUserId;
using EducationPlatformMicroservice.Catalog.Api.Features.Courses.GetById;
using EducationPlatformMicroservice.Catalog.Api.Features.Courses.Update;

namespace EducationPlatformMicroservice.Catalog.Api.Features.Courses
{
    public static class CourseEndpointExtensions
    {
        public static void AddCourseGroupEndpointExtensions(this WebApplication webApplication, ApiVersionSet apiVersionSet)
        {
            webApplication.MapGroup("api/v{version:apiVersion}/courses").WithTags("Courses")
                .WithApiVersionSet(apiVersionSet)
                .CreateCourseGroupItemEndpoint()
                .GetAllCourseGroupItemEndpoint()
                .GetByIdCourseGroupItemEndpoint()
                .UpdateCourseGroupItemEndpoint()
                .DeleteCourseGroupItemEndpoint()
                .GetAllByUserIdCourseGroupItemEndpoint();



        }
    }
}
