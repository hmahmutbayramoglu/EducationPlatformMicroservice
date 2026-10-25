using EducationPlatformMicroservice.Basket.Api.Features.Baskets.AddBasketItem;
using EducationPlatformMicroservice.Shared.Extensions;
using EducationPlatformMicroservice.Shared.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EducationPlatformMicroservice.Basket.Api.Features.Baskets.DeleteBasketItem
{
    public static class DeleteBasketItemEndpoint
    {
        public static RouteGroupBuilder DeleteBasketGroupItemEndpoint(this RouteGroupBuilder routeGroup)
        {

            //tek parametre diye böyle yaptık
            //birden fazla parametre gerekirse command ile ilerleriz
            routeGroup.MapDelete("/item/{id:guid}",
                //async([FromBody] DeleteBasketItemCommand command, [FromServices] IMediator mediator) =>
                async(Guid id, IMediator mediator) =>
                (await mediator.Send(new DeleteBasketItemCommand(id))).ToGenericResult())
                .WithName("DeleteBasketItem")
                .Produces<Guid>(statusCode: StatusCodes.Status201Created)
                .MapToApiVersion(1, 0)
                .AddEndpointFilter<ValidationFilter<DeleteBasketItemCommandValidator>>();

            return routeGroup;
        }
    }
}
