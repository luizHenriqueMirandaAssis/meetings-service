using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Schedule.Meetings.Infrastructure.Data.Context;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Schedule.Meetings.API.Swagger;
using Schedule.Meetings.Infrastructure.Ioc;
using Schedule.Meetings.API.Configurations;

namespace Schedule.Meetings.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkSqlServer()
               .AddDbContext<ScheduleMeetingsContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGeneration();
            services.AddApiVersioningAndExplorer();

            services.AddCors();
            services.AddSwaggerGen(c => c.EnableAnnotations());
            services.AddHealthChecks();
            services.ConfigureFluentValidation();
            services.AddMvc().AddNewtonsoftJson();
            NativeInjector.RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options => options.WithOrigins("http://localhost:3000/")
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
             
            app.UseRouting();

            app.UseEndpoints(options =>
            {
                options.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUIAndAddApiVersionEndPointBuilder(provider);
        }
    }
}
