using EducationPlatformMicroservice.Catalog.Api.Features.Courses.GetById;

namespace EducationPlatformMicroservice.Catalog.Api.Features.Courses.GetAllByUserId
{

    public static class GetAllByUserIdEndpoint
    {
        public static RouteGroupBuilder GetAllByUserIdCourseGroupItemEndpoint(this RouteGroupBuilder routeGroup)
        {
            routeGroup.MapGet("/user/{userId:guid}", async (IMediator mediator, Guid userId) =>
        (await mediator.Send(new GetAllCourseByUserIdQuery(userId))).ToGenericResult())
                        .MapToApiVersion(1, 0)
               .WithName("GetAllByUserIdCourses");

            return routeGroup;

        }
    }


}
