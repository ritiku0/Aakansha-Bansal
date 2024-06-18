using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Organisation.EntityFramework;
using System;

namespace Organisation.WPF.HostBuilders
{
    public static class AddDbContextHostBuilderExtensions
    {
        public static IHostBuilder AddDbContext(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                string connectionString = context.Configuration.GetConnectionString("sqlite");
                Action<DbContextOptionsBuilder> configureDbContext = o => o.UseSqlite(connectionString);

                services.AddDbContext<OrganisationDbContext>(configureDbContext);
                services.AddSingleton<OrganisationDbContextFactory>(new OrganisationDbContextFactory(configureDbContext));
            });

            return host;
        }
    }
}
