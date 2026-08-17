

namespace EducationPlatformMicroservice.Catalog.Api.Features.Courses.GetAll
{

    public static class GetAllCoursesEndpoint
    {
        public static RouteGroupBuilder GetAllCourseGroupItemEndpoint(this RouteGroupBuilder routeGroup)
        {

            routeGroup.MapGet("/", async (IMediator mediator) =>
             (await mediator.Send(new GetAllCoursesQuery())).ToGenericResult())
                        .MapToApiVersion(1, 0)
                .WithName("GetAllCourses");
                

            return routeGroup;
        }
    }
}
