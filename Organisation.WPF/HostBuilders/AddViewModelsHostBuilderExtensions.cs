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

                services.AddSingleton<CreateViewModel<ProfileViewModel>>(services => () => CreateProfileViewModel(services));
                services.AddSingleton<CreateViewModel<MachineViewModel>>(services => () => CreateMachineViewModel(services));
                services.AddSingleton<CreateViewModel<JobViewModel>>(services => () => CreateJobViewModel(services));
                services.AddSingleton<CreateViewModel<LoginViewModel>>(services => () => CreateLoginViewModel(services));
                services.AddSingleton<CreateViewModel<RegisterViewModel>>(services => () => CreateRegisterViewModel(services));                 
                services.AddSingleton<IOrganisationViewModelFactory, OrganisationViewModelFactory>();
              
                services.AddSingleton<ViewModelDelegateRenavigator<ProfileViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<MachineViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<JobViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<LoginViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<RegisterViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<AddNewMachineViewModel>>();
                services.AddSingleton<CreateViewModel<AddNewMachineViewModel>>(services => () => CreateAddMachineViewModel(services));
                services.AddSingleton<ViewModelDelegateRenavigator<AddNewJobViewModel>>();
                services.AddSingleton<CreateViewModel<AddNewJobViewModel>>(services => () => CreateAddJobViewModel(services));
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

        private static MachineViewModel CreateMachineViewModel(IServiceProvider services)
        {
            return new MachineViewModel(
                services.GetRequiredService<IAuthenticator>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<AddNewMachineViewModel>>());
        }

        private static JobViewModel CreateJobViewModel(IServiceProvider services)
        {
            return new JobViewModel(
                services.GetRequiredService<IAuthenticator>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<AddNewJobViewModel>>());
        }

        private static AddNewMachineViewModel CreateAddMachineViewModel(IServiceProvider services)
        {
            return new AddNewMachineViewModel(
                services.GetRequiredService<IAuthenticator>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<MachineViewModel>>());                
        }

        private static AddNewJobViewModel CreateAddJobViewModel(IServiceProvider services)
        {
            return new AddNewJobViewModel(
                services.GetRequiredService<IAuthenticator>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<JobViewModel>>());
        }
    }
}
