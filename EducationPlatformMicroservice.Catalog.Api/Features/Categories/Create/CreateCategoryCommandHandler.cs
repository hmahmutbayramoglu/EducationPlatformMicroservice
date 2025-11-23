using EducationPlatformMicroservice.Catalog.Api.Repositories;
using EducationPlatformMicroservice.Shared;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EducationPlatformMicroservice.Catalog.Api.Features.Categories.Create
{
    //repository ile ilerlemek daha mantıklı
    //eğer servis hep aynı orm ile ilerleyecekse repository kullanmaya gerek yok
    //DbContext üzerinden direkt ilerlenebilir
    public class CreateCategoryCommandHandler(AppDbContext context) : IRequestHandler<CreateCategoryCommand, ServiceResult<CreateCategoryResponse>>
    {
        public async Task<ServiceResult<CreateCategoryResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var existCategory = await context.Categories
          .AnyAsync(c => c.Name == request.name, cancellationToken);

            if (existCategory)
            {
                return ServiceResult<CreateCategoryResponse>.Error("Category Name already exist", $"The category name '{request.name}' already exist", HttpStatusCode.BadRequest);
            }
            var category = new Category
            {
                Id = NewId.NextSequentialGuid(),
                Name = request.name
            };
            await context.Categories.AddAsync(category, cancellationToken);

            await context.SaveChangesAsync(cancellationToken);

            return ServiceResult<CreateCategoryResponse>.SuccessAsCreated(new CreateCategoryResponse(category.Id),"<emty>");

        }
    }
}
