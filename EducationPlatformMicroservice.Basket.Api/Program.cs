using EducationPlatformMicroservice.Basket.Api;
using EducationPlatformMicroservice.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCommonServiceExtensions(typeof(BasketAssembly));

var app = builder.Build();

 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

 

app.Run();

 