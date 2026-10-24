using EducationPlatformMicroservice.Shared.Extensions;
using EducationPlatformMicroservice.Shared.Filters;
using MediatR;

namespace EducationPlatformMicroservice.Basket.Api.Features.Baskets.AddBasketItem
{
    public static class AddBasketItemEndpoint
    {
        public static RouteGroupBuilder AddBasketGroupItemEndpoint(this RouteGroupBuilder routeGroup)
        {
     
            routeGroup.MapPost("/item", async (AddBasketItemCommand command, IMediator mediator) =>
             (await mediator.Send(command)).ToGenericResult())
                .WithName("AddBasketItem")
                .Produces<Guid>(statusCode: StatusCodes.Status201Created)
                .MapToApiVersion(1, 0)
                .AddEndpointFilter<ValidationFilter<AddBasketItemCommand>>();

            return routeGroup;
        }

    }
}
