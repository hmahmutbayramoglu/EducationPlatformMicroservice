using EducationPlatformMicroservice.Catalog.Api.Features.Categories.Create;

namespace EducationPlatformMicroservice.Catalog.Api.Features.Categories
{
    public static class CategoryEndpointExtensions
    {
        public static void AddCategoryGroupEndpointExtensions(this WebApplication webApplication)
        {
            webApplication.MapGroup("api/categories")
                .CreateCategoryGroupItemEndpoint();
        }

    }
}
