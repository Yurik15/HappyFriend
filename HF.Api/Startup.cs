using System;
using HF.Api.Application;
using HFS.Infrastracture.DataAccess;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace HF.Api
{
    public class Startup
    {
        public Startup(
            IConfiguration configuration,
            IWebHostEnvironment env
            )
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContextInitialization(Configuration)               
                .AddMediatRTypes()
                .AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "HF API",
                    Description = "Happy Friend API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "HackDream Solutions",
                        Email = string.Empty,
                        Url = new Uri("https://twitter.com/spboyer"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Happy Friend License",
                        Url = new Uri("https://example.com/license"),
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HF API V1");
                c.RoutePrefix = "swagger";
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
    /// <summary>
    /// Use this class for add service configuration
    /// with extenssions to IServiceConllection
    /// </summary>
    internal static class HFConfigureServices
    {
        public static IServiceCollection AddDbContextInitialization(
                this IServiceCollection services,
                IConfiguration configuration
                /*IWebHostEnvironment env*/)
        {
            // it's can be uncommented when test environment will configured
            //if (env.IsEnvironment(Startup.EnvironmentTests))
            //{
            //    return services
            //        .AddDbContext<HfDbContext>(options => options.UseInMemoryDatabase("happyfriend"));
            //}

            return services
                .AddDbContext<HfDbContext>(options =>
                {
                    options.UseSqlServer(
                       configuration.GetConnectionString("HfDbConnection"),
                       b => b.MigrationsAssembly("HF.Api"));
                });
        }


        public static IServiceCollection AddMediatRTypes(
            this IServiceCollection services)
        {
            services
                .AddMediatR(typeof(Startup))
                .AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

            return services;
        }
    }


}
