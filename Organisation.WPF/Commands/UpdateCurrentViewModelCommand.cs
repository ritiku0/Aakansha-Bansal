using Organisation.WPF.State.Navigators;
using Organisation.WPF.ViewModels.Factories;
using System;
using System.Windows.Input;

namespace Organisation.WPF.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly INavigator _navigator;
        private readonly IOrganisationViewModelFactory _viewModelFactory;

        public UpdateCurrentViewModelCommand(INavigator navigator, IOrganisationViewModelFactory viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;

                _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
            }
        }
    }
}