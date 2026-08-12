using EducationPlatformMicroservice.Catalog.Api.Features.Courses;
using EducationPlatformMicroservice.Catalog.Api.Repositories;

namespace EducationPlatformMicroservice.Catalog.Api.Features.Categories
{
    public class Category : BaseEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = default!; // boş olamaz

        public List<Course>? Courses { get; set; }
    }
}
