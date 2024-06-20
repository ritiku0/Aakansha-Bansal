using Organisation.WPF.State.Authenticators;
using Organisation.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organisation.WPF.Commands
{   
    public class DeleteJobCommand : AsyncCommandBase
    {

        private readonly IAuthenticator _authenticator;
        private readonly JobViewModel _jobViewModel;

        public DeleteJobCommand(JobViewModel jobViewModel, IAuthenticator authenticator)
        {
            _jobViewModel = jobViewModel;
            _authenticator = authenticator;
            _jobViewModel.PropertyChanged += PropertyViewModel_PropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return _jobViewModel.CanUpdate(parameter) && base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _authenticator.DeleteJob(_jobViewModel.SelectedJobItem);

                var machine = _jobViewModel.Jobs.SingleOrDefault(m => m.Id == _jobViewModel.SelectedJobItem.Id);
                if (machine != null)
                {
                    _jobViewModel.Jobs.Remove(machine);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void PropertyViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_jobViewModel.CanUpdate))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
