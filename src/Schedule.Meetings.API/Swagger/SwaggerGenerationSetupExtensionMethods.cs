using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;

namespace Schedule.Meetings.API.Swagger
{
    public static class SwaggerGenerationSetupExtensionMethods
    {
        public static void AddSwaggerGeneration(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                // Integrate xml comments, add this when we have come that far.
                //options.IncludeXmlComments(XmlCommentsFilePath);

                // Describe all enums as strings instead of integers.
                //options.DescribeAllEnumsAsStrings();
            });
        }


        /// <summary>
        /// Adds SwaggerUI and adds a API-Version for each discovered endpoint.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="provider"></param>
        public static void UseSwaggerUIAndAddApiVersionEndPointBuilder(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseSwaggerUI(c =>
            {
                // Build a swagger endpoint for each discovered API version
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
            });
        }
    }
}
