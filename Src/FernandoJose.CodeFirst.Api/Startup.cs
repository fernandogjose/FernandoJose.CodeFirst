using FernandoJose.CodeFirst.Api.Middlewares;
using FernandoJose.CodeFirst.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Globalization;

namespace FernandoJose.CodeFirst.Api
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
            // Globalization
            CultureInfo.CurrentCulture = new CultureInfo("pt-BR");

            // Cors
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            // IoC
            BootStrapper.RegisterServices(services);

            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Fernando José - CQRS - CodeFirst",
                        Version = "v1",
                        Description = "API REST criada com o ASP.NET Core 3.1",
                        Contact = new OpenApiContact
                        {
                            Name = "Fernando José",
                            Url = new Uri("https://github.com/fernandogjose")
                        }
                    });
            });

            // Api
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Ativando middlewares para uso do Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fernando José V1"));

            // Cors
            app.UseCors("CorsPolicy");

            // Meus Middlewares
            app.UseMiddleware<RequestResponseMiddleware>();
            app.ConfigureExceptionHandler();

            // Padrão
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
