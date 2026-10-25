using EducationPlatformMicroservice.Shared;

namespace EducationPlatformMicroservice.Basket.Api.Features.Baskets.DeleteBasketItem
{
    public record DeleteBasketItemCommand (Guid Id): IRequestByServiceResult; 
   
}
