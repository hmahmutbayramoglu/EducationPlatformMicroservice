using EducationPlatformMicroservice.Basket.Api;
using EducationPlatformMicroservice.Basket.Api.Features.Baskets;
using EducationPlatformMicroservice.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCommonServiceExtensions(typeof(BasketAssembly));
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
});
builder.Services.AddVersionExtension();

var app = builder.Build();

 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddBasketGroupEndpointExtensions(app.AddVersionSetExtension());
 

app.Run();

 