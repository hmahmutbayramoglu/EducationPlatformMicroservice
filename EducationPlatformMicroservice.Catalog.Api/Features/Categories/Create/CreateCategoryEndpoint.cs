using EducationPlatformMicroservice.Shared.Extensions;
using EducationPlatformMicroservice.Shared.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EducationPlatformMicroservice.Catalog.Api.Features.Categories.Create
{
    public static class CreateCategoryEndpoint
    {
        public static RouteGroupBuilder CreateCategoryGroupItemEndpoint(this RouteGroupBuilder routeGroup)
        {
            //http://localhost:5000/api/categories/

            routeGroup.MapPost("/", async (CreateCategoryCommand command, IMediator mediator) =>
             (await mediator.Send(command)).ToGenericResult())
                .AddEndpointFilter<ValidationFilter<CreateCategoryCommand>>();

            return routeGroup;
        }
    }
}
