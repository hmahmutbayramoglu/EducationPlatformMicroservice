using AutoMapper;
using EducationPlatformMicroservice.Catalog.Api.Features.Courses.Create;

namespace EducationPlatformMicroservice.Catalog.Api.Features.Courses
{
    public class CourseMapping : Profile
    {
        public CourseMapping()
        {
            CreateMap<CreateCourseCommand, Course>();
        }
    }
}
