using EducationPlatformMicroservice.Catalog.Api;
using EducationPlatformMicroservice.Catalog.Api.Features.Categories;
using EducationPlatformMicroservice.Catalog.Api.Features.Options;
using EducationPlatformMicroservice.Catalog.Api.Repositories;
using EducationPlatformMicroservice.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);
 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Extensions
builder.Services.AddOptionExtension();
builder.Services.AddDatabaseServiceExtension();
builder.Services.AddCommonServiceExtensions(typeof(CatalogAssembly));


var app = builder.Build();



app.AddCategoryGroupEndpointExtensions();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

 
app.Run();

 