using EducationPlatformMicroservice.Basket.Api.Const;
using EducationPlatformMicroservice.Basket.Api.Dtos;
using EducationPlatformMicroservice.Shared;
using EducationPlatformMicroservice.Shared.Services;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Net;
using System.Text.Json;

namespace EducationPlatformMicroservice.Basket.Api.Features.Baskets.DeleteBasketItem
{
    public class DeleteBasketItemCommandHandler(IDistributedCache distributedCache, IIdentityService identityService) 
        : IRequestHandler<DeleteBasketItemCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(DeleteBasketItemCommand request, CancellationToken cancellationToken)
        {
            Guid userId = identityService.GetUserId;
            var cacheKey = String.Format(BasketConst.BasketCacheKey, userId);

            var basketAsString = await distributedCache.GetStringAsync(cacheKey, cancellationToken);

            if (string.IsNullOrEmpty(basketAsString))
            {
                return ServiceResult.Error("Basket not found.",HttpStatusCode.NotFound);
            }

            var currentBasket = JsonSerializer.Deserialize<BasketDto>(basketAsString);


            var basketItemToDelete = currentBasket!.BasketItems.FirstOrDefault(x => x.CourseId == request.CourseId);

            if (basketItemToDelete is null)
            {
                return ServiceResult.Error("Basket item not found.", HttpStatusCode.NotFound);
            }
            currentBasket.BasketItems.Remove(basketItemToDelete);

            basketAsString = JsonSerializer.Serialize(currentBasket);
            await distributedCache.SetStringAsync(cacheKey, basketAsString, cancellationToken);

            return ServiceResult.SuccessAsNoContent();
        }
    }
}
