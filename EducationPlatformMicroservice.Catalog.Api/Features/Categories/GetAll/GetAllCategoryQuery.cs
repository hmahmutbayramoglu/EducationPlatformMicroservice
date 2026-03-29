using EducationPlatformMicroservice.Catalog.Api.Features.Categories.Dtos;
using EducationPlatformMicroservice.Shared;
using MediatR;

namespace EducationPlatformMicroservice.Catalog.Api.Features.Categories.GetAll
{
    public class GetAllCategoryQuery : IRequest<ServiceResult<List<CategoryDto>>>
    {
    }
}
