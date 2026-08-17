using EducationPlatformMicroservice.Catalog.Api.Features.Courses.GetAll;
using System.Runtime.CompilerServices;

namespace EducationPlatformMicroservice.Catalog.Api.Features.Courses.GetById
{
    public static class GetCourseByIdEndpoint
    {

        public static RouteGroupBuilder GetByIdCourseGroupItemEndpoint(this RouteGroupBuilder routeGroup)
        {
            routeGroup.MapGet("/{id:guid}", async (IMediator mediator, Guid id) =>
        (await mediator.Send(new GetCourseByIdQuery(id))).ToGenericResult())
                        .MapToApiVersion(1, 0)
               .WithName("GetByIdCourses");

            return routeGroup;

        }
    }
}
