using Organisation.Domain.Models;
using Organisation.Domain.Services.AuthenticationServices;
using Organisation.WPF.State.Authenticators;
using Organisation.WPF.State.Navigators;
using Organisation.WPF.ViewModels;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Organisation.WPF.Commands
{
    public class AddNewMachineCommand : AsyncCommandBase
    {
        private readonly AddNewMachineViewModel _addNewMachineCommandl;
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _registerRenavigator;

        public AddNewMachineCommand(AddNewMachineViewModel registerViewModel, IAuthenticator authenticator, IRenavigator registerRenavigator)
        {
            _addNewMachineCommandl = registerViewModel;
            _authenticator = authenticator;
            _registerRenavigator = registerRenavigator;

            _addNewMachineCommandl.PropertyChanged += AddNewMachineCommand_PropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                Machine newMachine = new Machine
                {
                    MachineName = _addNewMachineCommandl.MachineName,
                    MachineNumber = _addNewMachineCommandl.MachineNumber,
                    ManufacturingDate = _addNewMachineCommandl.MfgDate,
                    ProductionSpeed = _addNewMachineCommandl.ProductionSpeed,
                    MachineImage = _addNewMachineCommandl.MachineImage
                };

                RegistrationResult registrationResult = await _authenticator.RegisterMachine(newMachine);

                if (registrationResult == RegistrationResult.Success)
                {
                    _registerRenavigator.Renavigate();

                }
            }
            catch (Exception)
            {
                Console.WriteLine("Registration failed.");
            }
        }

        private void AddNewMachineCommand_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(RegisterViewModel.CanRegister))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
