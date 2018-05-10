using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleRestfulAPIWithAspNetCore
{
    public class EvolveUtils
    {
        public void ConfigureServices(IServiceCollection services)
        {
            try
            {
                var cnx = new MySqlConnection($"Server=127.0.0.1;Port=3306;Database=evolve;Uid=root;Pwd=;SslMode=none;");
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
    }
}