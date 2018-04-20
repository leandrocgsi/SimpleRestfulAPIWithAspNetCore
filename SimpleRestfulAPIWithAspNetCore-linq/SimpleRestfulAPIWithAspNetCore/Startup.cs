using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleRestfulAPIWithAspNetCore.Business;
using SimpleRestfulAPIWithAspNetCore.Business.Implementations;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using SimpleRestfulAPIWithAspNetCore.Models.Entities.Context;
using SimpleRestfulAPIWithAspNetCore.Repository.Generic;
using SimpleRestfulAPIWithAspNetCore.Repository;

namespace SimpleRestfulAPIWithAspNetCore
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
            var connection = Configuration["MySqlConnection:MySqlConnectionString"];
            services.AddDbContext<MySQLContext>(options =>
                options.UseMySql(connection)
            );

            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My Simple RESTful API with ASP.NET Core", Version = "v1" });
            });

            services.AddScoped<IPersonBusiness, PersonBusinessImpl>();
            services.AddScoped<IExtractBusiness, ExtractBusinessImpl>();

            services.AddScoped<ExtractRepository>();

            //Adicionando a injeção de dependencias do repositorio genérico
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseMvc();
        }
    }
}
