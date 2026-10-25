using EducationPlatformMicroservice.Basket.Api.Features.Baskets.AddBasketItem;
using EducationPlatformMicroservice.Shared.Extensions;
using EducationPlatformMicroservice.Shared.Filters;
using MediatR;

namespace EducationPlatformMicroservice.Basket.Api.Features.Baskets.GetBasketItem
{
    public static class GetBasketEndpoint
    {
        public static RouteGroupBuilder GetBasketGroupItemEndpoint(this RouteGroupBuilder routeGroup)
        {

            routeGroup.MapGet("/user", async (IMediator mediator) =>
             (await mediator.Send(new GetBasketQuery())).ToGenericResult())
                .WithName("GetBasket")
                .Produces<Guid>(statusCode: StatusCodes.Status201Created)
                .MapToApiVersion(1, 0);
                
            return routeGroup;
        }
    }
}
