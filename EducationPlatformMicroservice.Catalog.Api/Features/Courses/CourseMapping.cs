using AutoMapper;
using EducationPlatformMicroservice.Catalog.Api.Features.Courses.Create;
using EducationPlatformMicroservice.Catalog.Api.Features.Courses.Dtos;

namespace EducationPlatformMicroservice.Catalog.Api.Features.Courses
{
    public class CourseMapping : Profile
    {
        public CourseMapping()
        {
            CreateMap<CreateCourseCommand, Course>();
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Feature, FeatureDto>().ReverseMap();
        }
    }
}
