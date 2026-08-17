
namespace EducationPlatformMicroservice.Catalog.Api.Features.Categories.GetAll
{
    public static class GetAllCategoriesEndpoint
    {
        public static RouteGroupBuilder GetAllCategoryGroupItemEndpoint(this RouteGroupBuilder routeGroup)
        {
            //http://localhost:5000/api/categories/

            routeGroup.MapGet("/",
                async (IMediator mediator) =>
                    (await mediator.Send(new GetAllCategoriesQuery())).ToGenericResult())
                        .MapToApiVersion(1, 0)
                .WithName("GetAllCategory");

            return routeGroup;
        }
    }
}
