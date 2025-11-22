using EducationPlatformMicroservice.Catalog.Api.Features.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;
using System.Reflection.Emit;

namespace EducationPlatformMicroservice.Catalog.Api.Repositories
{
    public class CourseEntityConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
          
            builder.ToCollection("courses");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedNever(); //MongoDB tarafında Id'yi biz atayacağız. Değer üretme diyoruz.
            builder.Property(c => c.Name).HasElementName("name").HasMaxLength(100);
            builder.Property(c => c.Description).HasElementName("description").HasMaxLength(1000);
            builder.Property(c => c.CreatedDate).HasElementName("createdDate");
            builder.Property(c => c.CreatorUserId).HasElementName("creatorUserId");
            builder.Property(c => c.CategoryId).HasElementName("categoryId");
            builder.Property(c => c.Picture).HasElementName("picture");
            builder.Ignore(c => c.Category); // İlişkiyi MongoDB tarafında tutmayacağız.

            builder.OwnsOne(c => c.Feature, feature => // ıddentity olarak tutulmuyor. Course entity'sinin içinde gömülü olarak tutuluyor.
            {
                feature.Property(f => f.Duration).HasElementName("duration");
                feature.Property(f => f.Rating).HasElementName("rating");
                feature.Property(f => f.EducatorFullName).HasElementName("educatorFullName").HasMaxLength(100);

            });
 
        }
    }
}
