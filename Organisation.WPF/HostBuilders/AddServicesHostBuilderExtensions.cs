
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Organisation.Domain.Models;
using Organisation.Domain.Services;
using Organisation.Domain.Services.AuthenticationServices;
using Organisation.EntityFramework.Services;

namespace Organisation.WPF.HostBuilders
{
    public static class AddServicesHostBuilderExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<IPasswordHasher, PasswordHasher>();

                services.AddSingleton<IAuthenticationService, AuthenticationService>();
                services.AddSingleton<IDataService<User>, AccountDataService>();
                services.AddSingleton<IAccountService, AccountDataService>();                
            });

            return host;
        }
    }
}
