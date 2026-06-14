using EducationPlatformMicroservice.Shared.Extensions;
using MediatR;

namespace EducationPlatformMicroservice.Catalog.Api.Features.Categories.GetById
{
    public static class GetCategoryByIdEndpoint
    {
        public static RouteGroupBuilder GetCategoryByIdGroupItemEndpoint(this RouteGroupBuilder routeGroup)
        {
           
            routeGroup.MapGet("/{id:guid}", // :guid kısıtlama belirtiyoruz guid olmayan bir id gelirse 404 dönecek
                async (IMediator mediator,Guid id) =>
                    (await mediator.Send(new GetCategoryByIdQuery(id))).ToGenericResult());
            return routeGroup;
        }

    }
}
