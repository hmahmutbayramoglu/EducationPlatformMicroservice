using EducationPlatformMicroservice.Catalog.Api.Features.Categories.Dtos;

namespace EducationPlatformMicroservice.Catalog.Api.Features.Courses.Dtos
{
    public record CourseDto (
        Guid Id, 
        string Name, 
        string Description,
        decimal Price, 
        string ImageUrl, 
        CategoryDto category, 
        FeatureDto Feature);
}
