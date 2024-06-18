using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Organisation.WPF.State.Authenticators;
using Organisation.WPF.State.Navigators;
using Organisation.WPF.ViewModels;
using Organisation.WPF.ViewModels.Factories;
using System;

namespace Organisation.WPF.HostBuilders
{
    public static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                            
                services.AddTransient<MainViewModel>();
                services.AddTransient<ProfileViewModel>();
                services.AddTransient<MachineViewModel>();
                services.AddTransient<JobViewModel>();


                services.AddSingleton<CreateViewModel<ProfileViewModel>>(services => () => CreateProfileViewModel(services));
                services.AddSingleton<CreateViewModel<MachineViewModel>>(services => () => services.GetRequiredService<MachineViewModel>());
                services.AddSingleton<CreateViewModel<JobViewModel>>(services => () => services.GetRequiredService<JobViewModel>());
                services.AddSingleton<CreateViewModel<LoginViewModel>>(services => () => CreateLoginViewModel(services));
                services.AddSingleton<CreateViewModel<RegisterViewModel>>(services => () => CreateRegisterViewModel(services));                
                services.AddSingleton<IOrganisationViewModelFactory, OrganisationViewModelFactory>();

                services.AddSingleton<ViewModelDelegateRenavigator<ProfileViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<LoginViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<RegisterViewModel>>();
            });

            return host;
        }

        private static ProfileViewModel CreateProfileViewModel(IServiceProvider services)
        {
            return new ProfileViewModel(services.GetRequiredService<IAuthenticator>());                
        }

        private static LoginViewModel CreateLoginViewModel(IServiceProvider services)
        { 
            return new LoginViewModel(
                services.GetRequiredService<IAuthenticator>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<ProfileViewModel>>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<RegisterViewModel>>());
        }

        private static RegisterViewModel CreateRegisterViewModel(IServiceProvider services)
        {
            return new RegisterViewModel(
                services.GetRequiredService<IAuthenticator>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>());
        }
    }
}
