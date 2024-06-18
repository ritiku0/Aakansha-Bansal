using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Organisation.WPF.Accounts;
using Organisation.WPF.State.Authenticators;
using Organisation.WPF.State.Navigators;

namespace Organisation.WPF.HostBuilders
{
    public static class AddStoresHostBuilderExtensions
    {
        public static IHostBuilder AddStores(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<INavigator, Navigator>();
                services.AddSingleton<IAuthenticator, Authenticator>();
                services.AddSingleton<IAccountStore, AccountStore>();

            });

            return host;
        }
    }
}
