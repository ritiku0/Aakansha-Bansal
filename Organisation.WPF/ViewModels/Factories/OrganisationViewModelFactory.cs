using Organisation.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organisation.WPF.ViewModels.Factories
{
    public class OrganisationViewModelFactory : IOrganisationViewModelFactory
    {
        private readonly CreateViewModel<ProfileViewModel> _createProfileViewModel;     
        private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;
        private readonly CreateViewModel<MachineViewModel> _createMachineViewModel;
        private readonly CreateViewModel<JobViewModel> _createJobViewModel;

        public OrganisationViewModelFactory(CreateViewModel<ProfileViewModel> createProfileViewModel,          
            CreateViewModel<LoginViewModel> createLoginViewModel, CreateViewModel<MachineViewModel> createMachineViewModel,
            CreateViewModel<JobViewModel> createJobViewModel
           )
        {
            _createProfileViewModel = createProfileViewModel;
           
            _createLoginViewModel = createLoginViewModel;
            _createMachineViewModel = createMachineViewModel;
            _createJobViewModel = createJobViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Login:
                    return _createLoginViewModel();
                case ViewType.Profile:
                    return _createProfileViewModel();
                case ViewType.MachineView:
                    return _createMachineViewModel();
                case ViewType.JobView:
                    return _createJobViewModel();
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
