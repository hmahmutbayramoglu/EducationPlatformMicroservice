using Asp.Versioning;
using Asp.Versioning.Builder;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatformMicroservice.Shared.Extensions
{
    public static class VersionExtensions
    {
        public static IServiceCollection AddVersionExtension(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader(); // url den version alınacak api/v1/courses bla bla
                                                                             //options.ApiVersionReader = ApiVersionReader.Combine(new HeaderApiVersionReader(),  // birden fazla yerden alınacaksa komine yapılabilir
                                                                             //    new QueryStringApiVersionReader(), new UrlSegmentApiVersionReader());


            }).AddApiExplorer(options => // swagger için ayarlama
            {
                options.GroupNameFormat = "'v'V";
                options.SubstituteApiVersionInUrl = true;
            });

            return services;
        }

        public static ApiVersionSet AddVersionSetExtension(this WebApplication webApplication) // minimal api için
        {
            var apiVersionSet = webApplication.NewApiVersionSet()
                .HasApiVersion(new ApiVersion(1,0))
                .HasApiVersion(new ApiVersion(1,2))
                .HasApiVersion(new ApiVersion(2,0))
                .ReportApiVersions()
                .Build();
            return apiVersionSet;
        }

    }
}
