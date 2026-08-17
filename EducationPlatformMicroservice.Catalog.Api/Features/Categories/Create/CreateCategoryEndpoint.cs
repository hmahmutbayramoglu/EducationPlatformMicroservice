using EducationPlatformMicroservice.Shared.Filters;
 
namespace EducationPlatformMicroservice.Catalog.Api.Features.Categories.Create
{
    public static class CreateCategoryEndpoint
    {
        public static RouteGroupBuilder CreateCategoryGroupItemEndpoint(this RouteGroupBuilder routeGroup)
        {
            //http://localhost:5000/api/categories/

            routeGroup.MapPost("/", async (CreateCategoryCommand command, IMediator mediator) =>
             (await mediator.Send(command)).ToGenericResult())
                .WithName("CreateCategory")
                .Produces<Guid>(statusCode: StatusCodes.Status201Created)
                .MapToApiVersion(1,0)
                .AddEndpointFilter<ValidationFilter<CreateCategoryCommand>>();

            return routeGroup;
        }
    }
}
