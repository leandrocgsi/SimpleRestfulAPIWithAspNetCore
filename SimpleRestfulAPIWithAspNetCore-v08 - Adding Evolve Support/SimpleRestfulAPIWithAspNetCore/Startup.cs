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
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace SimpleRestfulAPIWithAspNetCore
{
    public class Startup
    {
        private readonly ILogger _logger;
        private string _connectionString;

        public Startup(IConfiguration configuration, IHostingEnvironment env, ILogger<Startup> logger)
        {
            Configuration = configuration;
            Environment = env;
            _logger = logger;
            _connectionString = Configuration["MySqlConnection:MySqlConnectionString"];
        }

        public IConfiguration Configuration { get; }

        public IHostingEnvironment Environment { get; }

        public void ConfigureServices(IServiceCollection services /*, IConfiguration configuration*/)
        {

            if (Environment.IsProduction())
            {
                try
                {
                    var cnx = new MySqlConnection(_connectionString);

                    var evolve = new Evolve.Evolve("evolve.json", cnx, msg => _logger.LogInformation(msg)) // retrieve the MSBuild configuration
                    {
                        Locations = new List<string> { "db/migrations" }, // exclude db/datasets from production environment
                        IsEraseDisabled = true, // ensure erase command is disabled in production
                    };

                    evolve.Migrate();
                }
                catch (Exception ex)
                {
                    _logger.LogCritical("Database migration failed.", ex);
                    throw;
                }
            }

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
