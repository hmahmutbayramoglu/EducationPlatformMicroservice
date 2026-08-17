using EducationPlatformMicroservice.Catalog.Api.Features.Courses.Create;
using EducationPlatformMicroservice.Shared.Filters;

namespace EducationPlatformMicroservice.Catalog.Api.Features.Courses.Delete
{
    public static class DeleteCourseEndpoint
    {
        public static RouteGroupBuilder DeleteCourseGroupItemEndpoint(this RouteGroupBuilder routeGroup)
        {

            routeGroup.MapDelete("/{id:guid}",
                async (IMediator mediator, Guid id) =>
                      (await mediator.Send(new DeleteCourseCommand(id))).ToGenericResult())
                 .MapToApiVersion(1, 0)
                .WithName("DeleteCourse")
                .AddEndpointFilter<ValidationFilter<DeleteCourseCommand>>();

            return routeGroup;
        }
    }
}
