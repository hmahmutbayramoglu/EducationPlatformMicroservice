using AutoMapper;
using EducationPlatformMicroservice.Catalog.Api.Features.Categories.Dtos;

namespace EducationPlatformMicroservice.Catalog.Api.Features.Categories
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category,CategoryDto>().ReverseMap();
        }
    }
}
