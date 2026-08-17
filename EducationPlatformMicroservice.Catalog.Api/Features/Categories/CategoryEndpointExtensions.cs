using Asp.Versioning.Builder;
using EducationPlatformMicroservice.Catalog.Api.Features.Categories.Create;
using EducationPlatformMicroservice.Catalog.Api.Features.Categories.GetAll;
using EducationPlatformMicroservice.Catalog.Api.Features.Categories.GetById;

namespace EducationPlatformMicroservice.Catalog.Api.Features.Categories
{
    public static class CategoryEndpointExtensions
    {
        public static void AddCategoryGroupEndpointExtensions(this WebApplication webApplication, ApiVersionSet apiVersionSet)
        {
            webApplication.MapGroup("api/v{version:apiVersion}/categories").WithTags("Categories")
                .WithApiVersionSet(apiVersionSet)
                .CreateCategoryGroupItemEndpoint()
                .GetAllCategoryGroupItemEndpoint()
                .GetCategoryByIdGroupItemEndpoint();
        }

    }
}
