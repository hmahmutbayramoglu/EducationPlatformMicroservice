using EducationPlatformMicroservice.Catalog.Api.Features.Categories.Dtos;
using EducationPlatformMicroservice.Shared;
using MediatR;

namespace EducationPlatformMicroservice.Catalog.Api.Features.Categories.GetById
{
    public record GetCategoryByIdQuery(Guid Id) : IRequest<ServiceResult<CategoryDto>>;
 
}
