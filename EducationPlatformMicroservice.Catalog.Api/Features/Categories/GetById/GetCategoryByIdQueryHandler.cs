using AutoMapper;
using EducationPlatformMicroservice.Catalog.Api.Features.Categories.Dtos;
using EducationPlatformMicroservice.Catalog.Api.Repositories;
using EducationPlatformMicroservice.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EducationPlatformMicroservice.Catalog.Api.Features.Categories.GetById
{
    public class GetCategoryByIdQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetCategoryByIdQuery, ServiceResult<CategoryDto>>
    {
        public async Task<ServiceResult<CategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {

            var hasCategory = await context.Categories.FindAsync(request.Id, cancellationToken);

            if (hasCategory is null)
            {
                return ServiceResult<CategoryDto>.Error("Category not found",
                 $"The category with Id({request.Id}) was not found",
                 HttpStatusCode.NotFound);
            }

            var categoryDtos = mapper.Map<CategoryDto>(hasCategory);

            return ServiceResult<CategoryDto>.SuccessAsOk(categoryDtos);
        }
    }
}
