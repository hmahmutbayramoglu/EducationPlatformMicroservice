using EducationPlatformMicroservice.Catalog.Api.Features.Categories.Dtos;


namespace EducationPlatformMicroservice.Catalog.Api.Features.Categories.GetById
{
    public record GetCategoryByIdQuery(Guid Id) : IRequestByServiceResult<CategoryDto>;
 
}
