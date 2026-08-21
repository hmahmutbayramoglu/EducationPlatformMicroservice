using EducationPlatformMicroservice.Basket.Api.Const;
using EducationPlatformMicroservice.Basket.Api.Dtos;
using EducationPlatformMicroservice.Shared;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace EducationPlatformMicroservice.Basket.Api.Features.Baskets.AddBasketItem
{
    public class AddBasketItemCommandHandler(IDistributedCache distributedCache) : IRequestHandler<AddBasketItemCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(AddBasketItemCommand request, CancellationToken cancellationToken)
        {

            //Fast fail


            // TODO: change userId
            Guid userId = Guid.NewGuid();
            var cacheKey = String.Format(BasketConst.BasketCacheKey, userId);

            var basketAsString = await distributedCache.GetStringAsync(cacheKey, cancellationToken);

            BasketDto? currentBasket;

            var newBasketItem = new BasketItemDto
            {
                CourseId = request.CourseId,
                CourseName = request.CourseName,
                CoursePrice = request.CoursePrice,
                ImageUrl = request.ImageUrl,
                PriceByApplyDiscountRate = null
            };

            if (string.IsNullOrEmpty(basketAsString))
            {
                currentBasket = new BasketDto
                {
                    UserId = userId,
                    BasketItems = [newBasketItem]
                };
                await CreateCacheAsync(currentBasket, cacheKey, cancellationToken);

                return ServiceResult.SuccessAsNoContent();
            }

            currentBasket = JsonSerializer.Deserialize<BasketDto>(basketAsString);

            var existingBasketItem = currentBasket!.BasketItems.FirstOrDefault(x => x.CourseId == request.CourseId);
            if (existingBasketItem is not null)
            {
                currentBasket.BasketItems.Remove(existingBasketItem);
            }
            currentBasket.BasketItems.Add(newBasketItem);

            await CreateCacheAsync(currentBasket, cacheKey, cancellationToken);

            return ServiceResult.SuccessAsNoContent();


        }


        private async Task CreateCacheAsync(BasketDto basket, string cacheKey, CancellationToken cancellationToken)
        {
            var basketAsString = JsonSerializer.Serialize(basket);
            await distributedCache.SetStringAsync(cacheKey, basketAsString, cancellationToken);

        }
    }
}
