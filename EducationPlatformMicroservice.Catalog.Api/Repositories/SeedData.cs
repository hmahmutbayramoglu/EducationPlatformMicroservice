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

            dbContext.Database.AutoTransactionBehavior = AutoTransactionBehavior.Never; // ...
 
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

            if (!dbContext.Courses.Any())
            {
                var categories = await dbContext.Categories.FirstAsync();

                var randomUserId = NewId.NextSequentialGuid();
                var courses = new List<Course>
                {
                    new()
                    {
                        Id = NewId.NextSequentialGuid(),
                        CreatorUserId = randomUserId,
                        Name = "Java Course",
                        Description = "Java programming from beginner to advanced level.",
                        Price = 100,
                        CreatedDate = DateTime.UtcNow,
                        Feature = new Feature
                        {
                            Duration = 10,
                            Rating = 4,
                            EducatorFullName = "Mahmut Hüseyin Bayramoğlu"
                        },
                        CategoryId = categories.Id
                    },
                    new()
                    {
                        Id = NewId.NextSequentialGuid(),
                        CreatorUserId = randomUserId,
                        Name = "C# Programming Course",
                        Description = "Learn C# programming fundamentals and object-oriented programming.",
                        Price = 150,
                        CreatedDate = DateTime.UtcNow,
                        Feature = new Feature
                        {
                            Duration = 15,
                            Rating = 5,
                            EducatorFullName = "Ahmet Yılmaz"
                        },
                        CategoryId = categories.Id
                    },
                    new()
                    {
                        Id = NewId.NextSequentialGuid(),
                        CreatorUserId = randomUserId,
                        Name = "ASP.NET Core Web API",
                        Description = "Build modern and scalable RESTful APIs with ASP.NET Core.",
                        Price = 200,
                        CreatedDate = DateTime.UtcNow,
                        Feature = new Feature
                        {
                            Duration = 20,
                            Rating = 5,
                            EducatorFullName = "Mehmet Kaya"
                        },
                        CategoryId = categories.Id
                    },
                    new()
                    {
                        Id = NewId.NextSequentialGuid(),
                        CreatorUserId = randomUserId,
                        Name = "Angular Course",
                        Description = "Create modern and dynamic web applications using Angular.",
                        Price = 175,
                        CreatedDate = DateTime.UtcNow,
                        Feature = new Feature
                        {
                            Duration = 18,
                            Rating = 4,
                            EducatorFullName = "Ayşe Demir"
                        },
                        CategoryId = categories.Id
                    },
                    new()
                    {
                        Id = NewId.NextSequentialGuid(),
                        CreatorUserId = randomUserId,
                        Name = "React Development",
                        Description = "Learn React and build modern single-page applications.",
                        Price = 160,
                        CreatedDate = DateTime.UtcNow,
                        Feature = new Feature
                        {
                            Duration = 16,
                            Rating = 4,
                            EducatorFullName = "Emre Şahin"
                        },
                        CategoryId = categories.Id
                    },
                    new()
                    {
                        Id = NewId.NextSequentialGuid(),
                        CreatorUserId = randomUserId,
                        Name = "Python Programming",
                        Description = "Learn Python programming from the basics to advanced concepts.",
                        Price = 120,
                        CreatedDate = DateTime.UtcNow,
                        Feature = new Feature
                        {
                            Duration = 14,
                            Rating = 5,
                            EducatorFullName = "Zeynep Aydın"
                        },
                        CategoryId = categories.Id
                    },
                    new()
                    {
                        Id = NewId.NextSequentialGuid(),
                        CreatorUserId = randomUserId,
                        Name = "SQL and Database Management",
                        Description = "Learn SQL queries, relational databases, and database management.",
                        Price = 90,
                        CreatedDate = DateTime.UtcNow,
                        Feature = new Feature
                        {
                            Duration = 8,
                            Rating = 4,
                            EducatorFullName = "Burak Çelik"
                        },
                        CategoryId = categories.Id
                    },
                    new()
                    {
                        Id = NewId.NextSequentialGuid(),
                        CreatorUserId = randomUserId,
                        Name = "Docker and Kubernetes",
                        Description = "Learn containerization and orchestration with Docker and Kubernetes.",
                        Price = 220,
                        CreatedDate = DateTime.UtcNow,
                        Feature = new Feature
                        {
                            Duration = 22,
                            Rating = 5,
                            EducatorFullName = "Can Özdemir"
                        },
                        CategoryId = categories.Id
                    },
                    new()
                    {
                        Id = NewId.NextSequentialGuid(),
                        CreatorUserId = randomUserId,
                        Name = "Microservices Architecture",
                        Description = "Design and develop scalable applications using microservice architecture.",
                        Price = 250,
                        CreatedDate = DateTime.UtcNow,
                        Feature = new Feature
                        {
                            Duration = 25,
                            Rating = 5,
                            EducatorFullName = "Murat Arslan"
                        },
                        CategoryId = categories.Id
                    },
                    new()
                    {
                        Id = NewId.NextSequentialGuid(),
                        CreatorUserId = randomUserId,
                        Name = "Clean Architecture with .NET",
                        Description = "Learn Clean Architecture, SOLID principles, and design patterns with .NET.",
                        Price = 230,
                        CreatedDate = DateTime.UtcNow,
                        Feature = new Feature
                        {
                            Duration = 21,
                            Rating = 5,
                            EducatorFullName = "Mahmut Hüseyin Bayramoğlu"
                        },
                        CategoryId = categories.Id
                    }
                };

                dbContext.Courses.AddRange(courses);
                await dbContext.SaveChangesAsync();
            }

        }

    }
}
