
namespace EducationPlatformMicroservice.Catalog.Api.Features.Categories.GetAll
{
    public static class GetAllCategoryEndpoint
    {
        public static RouteGroupBuilder GetAllCategoryGroupItemEndpoint(this RouteGroupBuilder routeGroup)
        {
            //http://localhost:5000/api/categories/

            routeGroup.MapGet("/",
                async (IMediator mediator) =>
                    (await mediator.Send(new GetAllCategoryQuery())).ToGenericResult());

            return routeGroup;
        }
    }
}
