using EducationPlatformMicroservice.Basket.Api.Dtos;
using EducationPlatformMicroservice.Shared;
using MediatR;

namespace EducationPlatformMicroservice.Basket.Api.Features.Baskets.GetBasketItem
{
    public record GetBasketQuery: IRequestByServiceResult<BasketDto>;
     
}
