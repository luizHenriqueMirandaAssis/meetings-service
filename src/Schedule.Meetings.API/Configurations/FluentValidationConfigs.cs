using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Schedule.Meetings.API.Filters;
using FluentValidation.AspNetCore;
using Schedule.Meetings.API.V1.Validators;

namespace Schedule.Meetings.API.Configurations
{
    public static class FluentValidationConfigs
    {
        public static void ConfigureFluentValidation(this IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(new ValidatorFilter());
            })
                .SetCompatibilityVersion(CompatibilityVersion.Latest)
                .AddFluentValidation(configuration =>
                {
                    configuration.RegisterValidatorsFromAssemblyContaining<ScheduleMeetingsValidator>();
                });

            // A validação do modelo é de responsabilidade do FluentValidation
            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
        }

        public static void UseFluentValidation(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
        }
    }
}
