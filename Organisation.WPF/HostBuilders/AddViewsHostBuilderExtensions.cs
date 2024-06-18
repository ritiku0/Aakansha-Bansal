using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Organisation.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organisation.WPF.HostBuilders
{
    public static class AddViewsHostBuilderExtensions
    {
        public static IHostBuilder AddViews(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));
            });

            return host;
        }
    }
}
