using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
 

namespace EducationPlatformMicroservice.Shared.Extensions
{
    public static class CommonServiceExtensions
    {
        public static IServiceCollection AddCommonServiceExtensions(this IServiceCollection services, Type assembly)
        {
           services.AddHttpContextAccessor();
            services.AddMediatR(x=> x.RegisterServicesFromAssemblyContaining(assembly));
            
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining(assembly);

            services.AddAutoMapper(assembly);

            return services;
        }
    }
}
