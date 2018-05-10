using System;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using SimpleRestfulAPIWithAspNetCore.Models.Entities.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Rewrite;
using SimpleRestfulAPIWithAspNetCore.Business;
using SimpleRestfulAPIWithAspNetCore.Business.Implementations;
using SimpleRestfulAPIWithAspNetCore.Repository.Generic;
using Swashbuckle.AspNetCore.Swagger;

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

        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration["MySqlConnection:MySqlConnectionString"];
            services.AddDbContext<MySQLContext>(options =>
                options.UseMySql(connection)
            );

            if (Environment.IsDevelopment())
            {
                try
                {
                    var cnx = new MySql.Data.MySqlClient.MySqlConnection("Server=localhost;Port=3306;Database=evolve;Uid=root;Pwd=;SslMode=none;");

                    var evolve = new Evolve.Evolve("evolve.json", cnx, msg => _logger.LogInformation(msg)) 
                    {
                        Locations = new List<string> { "db/migrations" },
                        IsEraseDisabled = true,
                    };

                    evolve.Migrate();
                }
                catch (Exception ex)
                {
                    _logger.LogCritical("Database migration failed.", ex);
                    throw;
                }
            }

            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My Simple RESTful API with ASP.NET Core", Version = "v1" });
            });

            services.AddScoped<IPersonBusiness, PersonBusinessImpl>();
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
