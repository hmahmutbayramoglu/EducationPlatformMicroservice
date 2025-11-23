using EducationPlatformMicroservice.Shared;
using MediatR;

namespace EducationPlatformMicroservice.Catalog.Api.Features.Categories.Create
{
    public record CreateCategoryCommand(string name):IRequest<ServiceResult<CreateCategoryResponse>>;







    //public record X
    //{
    //    public string Name { get; init; }

    //    public X(string name)
    //    {
    //        Name = name;
    //    }
    //    var x = new X("education");
    //    x.Name = "sport"; //Immutable özellik - değiştirilemez
    //}

}
