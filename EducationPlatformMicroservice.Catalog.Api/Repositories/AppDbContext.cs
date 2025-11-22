using EducationPlatformMicroservice.Catalog.Api.Features.Categories;
using EducationPlatformMicroservice.Catalog.Api.Features.Courses;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using System.Reflection;

namespace EducationPlatformMicroservice.Catalog.Api.Repositories
{
    public class AppDbContext (DbContextOptions<AppDbContext> options):DbContext(options)
    {

        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Table/Row/Column 
            //Collection/Doocument/Field

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());



        }
    }
}
