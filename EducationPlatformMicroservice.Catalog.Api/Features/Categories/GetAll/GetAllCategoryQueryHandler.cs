using EducationPlatformMicroservice.Catalog.Api.Features.Categories.Dtos;
using EducationPlatformMicroservice.Catalog.Api.Repositories;
using EducationPlatformMicroservice.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EducationPlatformMicroservice.Catalog.Api.Features.Categories.GetAll
{
    public class GetAllCategoryQueryHandler(AppDbContext appDbContext) : IRequestHandler<GetAllCategoryQuery, ServiceResult<List<CategoryDto>>>
    {
        public async Task<ServiceResult<List<CategoryDto>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {

            var categories = appDbContext.Categories.ToListAsync();
            var categoryDtos = categories.Result.Select(c => new CategoryDto(c.Id, c.Name)).ToList();
            return ServiceResult<List<CategoryDto>>.SuccessAsOk(categoryDtos);
        }
    }
}
