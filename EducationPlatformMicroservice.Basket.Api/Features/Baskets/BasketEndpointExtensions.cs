using Asp.Versioning.Builder;
using EducationPlatformMicroservice.Basket.Api.Features.Baskets.AddBasketItem;
using EducationPlatformMicroservice.Basket.Api.Features.Baskets.DeleteBasketItem;
using EducationPlatformMicroservice.Basket.Api.Features.Baskets.GetBasketItem;

namespace EducationPlatformMicroservice.Basket.Api.Features.Baskets
{
    public static class BasketEndpointExtensions
    {
        public static void AddBasketGroupEndpointExtensions(this WebApplication webApplication, ApiVersionSet apiVersionSet)
        {
            webApplication.MapGroup("api/v{version:apiVersion}/baskets").WithTags("Baskets")
                .WithApiVersionSet(apiVersionSet)
               .AddBasketGroupItemEndpoint()
               .DeleteBasketGroupItemEndpoint()
               .GetBasketGroupItemEndpoint();
        }
    }
}
