using EducationPlatformMicroservice.Catalog.Api.Features.Options;
using EducationPlatformMicroservice.Catalog.Api.Repositories;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);
 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Extensions
builder.Services.AddOptionExtension();
builder.Services.AddDatabaseServiceExtension();

var app = builder.Build();

 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

 
app.Run();

 