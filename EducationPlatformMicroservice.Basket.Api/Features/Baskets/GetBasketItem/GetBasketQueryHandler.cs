using EducationPlatformMicroservice.Basket.Api.Const;
using EducationPlatformMicroservice.Basket.Api.Dtos;
using EducationPlatformMicroservice.Shared;
using EducationPlatformMicroservice.Shared.Services;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Net;
 

namespace EducationPlatformMicroservice.Basket.Api.Features.Baskets.GetBasketItem
{
    public class GetBasketQueryHandler(IDistributedCache distributedCache, IIdentityService identityService)
        : IRequestHandler<GetBasketQuery, ServiceResult<BasketDto>>
    {
        public async Task<ServiceResult<BasketDto>> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
      
            var cacheKey = string.Format(BasketConst.BasketCacheKey, identityService.GetUserId);
            var basketAsString = await distributedCache.GetStringAsync(cacheKey, token: cancellationToken);

            
            if (string.IsNullOrEmpty(basketAsString))
            {
                return ServiceResult<BasketDto>.Error("Basket not found", HttpStatusCode.NotFound);
            }

             var basket = System.Text.Json.JsonSerializer.Deserialize<BasketDto>(basketAsString);
            

            return ServiceResult<BasketDto>.SuccessAsOk(basket);

        }
    }
}
