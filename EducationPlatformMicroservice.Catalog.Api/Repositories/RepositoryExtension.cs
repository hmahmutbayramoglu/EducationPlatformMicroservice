using EducationPlatformMicroservice.Catalog.Api.Features.Options;
using MongoDB.Driver;

namespace EducationPlatformMicroservice.Catalog.Api.Repositories
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddDatabaseServiceExtension(this IServiceCollection services)
        {

            services.AddSingleton<IMongoClient, MongoClient>(sp =>
            {
                var mongoOption = sp.GetRequiredService<MongoOption>();
                return new MongoClient(mongoOption.ConnnectionString);
            });

            services.AddScoped(sp =>
            {
                var mongoClient = sp.GetRequiredService<IMongoClient>();
                var mongoOption = sp.GetRequiredService<MongoOption>();
                var mongoDatabase = mongoClient.GetDatabase(mongoOption.DatabaseName);
                return AppDbContext.Create(mongoDatabase);
            });
            return services;

        }
    }
}
