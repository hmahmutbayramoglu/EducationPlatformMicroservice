using EducationPlatformMicroservice.Catalog.Api;
using EducationPlatformMicroservice.Catalog.Api.Features.Categories;
using EducationPlatformMicroservice.Catalog.Api.Features.Courses;
using EducationPlatformMicroservice.Catalog.Api.Features.Options;
using EducationPlatformMicroservice.Catalog.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);
 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Extensions
builder.Services.AddOptionExtension();
builder.Services.AddDatabaseServiceExtension();
builder.Services.AddCommonServiceExtensions(typeof(CatalogAssembly));
builder.Services.AddVersionExtension();

var app = builder.Build();


app.AddSeedDataExtension().ContinueWith(x =>
{
    Console.WriteLine(x.IsFaulted ? x.Exception?.Message : "Seed Data has been saved successfully");
});

app.AddCategoryGroupEndpointExtensions(app.AddVersionSetExtension());
app.AddCourseGroupEndpointExtensions(app.AddVersionSetExtension());



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

 
app.Run();

 