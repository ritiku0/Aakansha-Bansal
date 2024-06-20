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

    public class DeleteMachineCommand : AsyncCommandBase
    {

        private readonly IAuthenticator _authenticator;
        private readonly MachineViewModel _machineViewModel;

        public DeleteMachineCommand(MachineViewModel machineViewModel, IAuthenticator authenticator)
        {
            _machineViewModel = machineViewModel;
            _authenticator = authenticator;
            _machineViewModel.PropertyChanged += PropertyViewModel_PropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return _machineViewModel.CanUpdate(parameter) && base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _authenticator.DeleteMachine(_machineViewModel.SelectedMachineItem);

                var machine = _machineViewModel.Machines.SingleOrDefault(m => m.Id == _machineViewModel.SelectedMachineItem.Id);
                if (machine != null)
                {
                    _machineViewModel.Machines.Remove(machine);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void PropertyViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_machineViewModel.CanUpdate))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
