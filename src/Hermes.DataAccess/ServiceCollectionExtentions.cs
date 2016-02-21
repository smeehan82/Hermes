using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.DataAccess
{
    public static class ServiceCollectionExtentions
    {
        public static void AddHermesDataContext(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            // @TODO get strongly typed options from configuration instead of magic strings
            //Tells us how to connect to the db
            var defaultConnectionOptions = configuration.GetSection("DefaultConnection");
            var settings = new DataAccessOptions();
            settings.DefaultConnection.ConntectionString = defaultConnectionOptions["ConnectionString"];
            DatabaseType dbType;
            if (Enum.TryParse<DatabaseType>(defaultConnectionOptions["DatabaseType"], out dbType))
            {
                settings.DefaultConnection.Type = dbType;
            }
            //connects to the db
            if (settings.DefaultConnection.Type == DatabaseType.MsSqlServer)
            {
                services.AddEntityFramework()
                    .AddSqlServer()
                    .AddDbContext<DataContext>(options =>
                    {
                        options.UseSqlServer(settings.DefaultConnection.ConntectionString);
                    });

                services.AddScoped<IDataContext, DataContext>();
            }
            else
            {
                throw new NotImplementedException($"Database type ({settings.DefaultConnection.Type}) not yet implemented.");
            }
        }
    }
}
