using EducationPlatformMicroservice.Catalog.Api.Features.Categories.Create;
using EducationPlatformMicroservice.Shared.Filters;
using Microsoft.AspNetCore.Mvc;

namespace EducationPlatformMicroservice.Catalog.Api.Features.Courses.Create
{
    public static class CreateCourseEndpoint
    {
        public static RouteGroupBuilder CreateCourseGroupItemEndpoint(this RouteGroupBuilder routeGroup)
        {

            routeGroup.MapPost("/", async (CreateCourseCommand command, IMediator mediator) =>
             (await mediator.Send(command)).ToGenericResult())
                .WithName("CreateCourse")
                .Produces<Guid>(statusCode: StatusCodes.Status201Created) // hangi durumda nelerin döneceğini belirtiyoruz.
                .Produces(statusCode: StatusCodes.Status404NotFound)
                .Produces<ProblemDetails>(statusCode: StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(statusCode: StatusCodes.Status500InternalServerError)
                .AddEndpointFilter<ValidationFilter<CreateCourseCommand>>();

            return routeGroup;
        }
    }
}
