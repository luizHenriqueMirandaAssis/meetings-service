using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace Schedule.Meetings.API.Swagger
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiVersionDescriptionProvider provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => this.provider = provider;

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }

        // <summary>
        /// Creates an API-Version info object and fills it with data.
        /// </summary>
        /// <param name="description"></param>
        /// <returns>Returns an OpenApiInfo object with API-Version info.</returns>
        public OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = $"Schedule Meetings {description.ApiVersion}",
                Version = description.ApiVersion.ToString(),
                Description = "Meeting scheduling service",
                Contact = new OpenApiContact() { Name = "Luiz Henrique Miranda de Assis", Email = "luiz.assis.ti@gmail.com" },
                //TermsOfService = "UnComment and put the URI here to the terms of service.",
                License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
            };

            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }
    }
}
