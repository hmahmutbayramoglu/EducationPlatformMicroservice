using EducationPlatformMicroservice.Catalog.Api.Features.Categories;
using EducationPlatformMicroservice.Catalog.Api.Features.Courses;

namespace EducationPlatformMicroservice.Catalog.Api.Repositories
{
    public static class SeedData
    {
        public static async Task AddSeedDataExtension(this WebApplication application)
        {

            using var scope = application.Services.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            if (!dbContext.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category {Id = NewId.NextSequentialGuid(), Name = "Programming" },
                    new Category {Id = NewId.NextSequentialGuid(), Name = "Design" },
                    new Category {Id = NewId.NextSequentialGuid(), Name = "Marketing" },
                    new Category {Id = NewId.NextSequentialGuid(), Name = "Business" },
                    new Category {Id = NewId.NextSequentialGuid(), Name = "Photography" }
                };
                dbContext.Categories.AddRange(categories);
                await dbContext.SaveChangesAsync();
            }

            if (dbContext.Courses.Any())
            {
                var categories = await dbContext.Categories.FirstAsync();

                var randomUserId = NewId.NextSequentialGuid();
                var courses = new List<Course>
                {
                    new()
                    {
                        Id = NewId.NextSequentialGuid(), // ardışık guid oluşturduğu için nextGuid den daha iyi indexleme sağlıyor.
                        CreatorUserId = randomUserId,
                        Name = "Java Course",
                        Description = "Java Course description",
                        Price = 100,
                        CreatedDate = DateTime.Now,
                        Feature = new Feature {Duration  =10 , Rating = 4, EducatorFullName = "Mahmut Hüseyin Bayramoğlu"},
                        CategoryId = categories.First().Id
                    },
                };
            }

        }

    }
}
