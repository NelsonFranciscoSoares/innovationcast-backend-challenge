using Backend.Challenge.Domain.Entities;
using Backend.Challenge.Infrastructure.Persistence.DataContext;
using Backend.Challenge.Kernel.API;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Backend.Challenge.API.Configurations
{
    public static class ApiConfiguration
    {
        public static void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DiscussaoDBContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DiscussaoConnectionString")));

            services.AddControllers()
                    .AddJsonOptions(options => 
                        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull);

            services.AddCors(options =>
            {
                options.AddPolicy("Total",
                    builder =>
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());
            });

            GetConfigurationData(services, configuration);
        }

        private static void GetConfigurationData(IServiceCollection services, IConfiguration configuration)
        {
            var utilizadorId = configuration.GetConfigurationValueByName("UtilizadorId");
            services.AddSingleton(new UtilizadorEntity(Guid.Parse(utilizadorId)));
        }

        public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("Total");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }
    }
}
