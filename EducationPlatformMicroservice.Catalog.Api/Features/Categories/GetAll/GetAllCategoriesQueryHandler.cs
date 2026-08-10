using AutoMapper;
using EducationPlatformMicroservice.Catalog.Api.Features.Categories.Dtos;
using EducationPlatformMicroservice.Catalog.Api.Repositories;


namespace EducationPlatformMicroservice.Catalog.Api.Features.Categories.GetAll
{
    public class GetAllCategoriesQueryHandler(AppDbContext appDbContext,IMapper mapper) : IRequestHandler<GetAllCategoriesQuery, ServiceResult<List<CategoryDto>>>
    {
        public async Task<ServiceResult<List<CategoryDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            
            var categories = appDbContext.Categories.ToListAsync(cancellationToken);
            var categoryDtos = mapper.Map<List<CategoryDto>>(await categories);
            return ServiceResult<List<CategoryDto>>.SuccessAsOk(categoryDtos);
        }
    }
}
