using Organisation.Domain.Models;
using Organisation.Domain.Services.AuthenticationServices;
using Organisation.WPF.State.Authenticators;
using Organisation.WPF.State.Navigators;
using Organisation.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organisation.WPF.Commands
{
    public class AddNewJobCommand : AsyncCommandBase
    {
        private readonly AddNewJobViewModel _addNewJobCommand;
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _registerRenavigator;

        public AddNewJobCommand(AddNewJobViewModel registerViewModel, IAuthenticator authenticator, IRenavigator registerRenavigator)
        {
            _addNewJobCommand = registerViewModel;
            _authenticator = authenticator;
            _registerRenavigator = registerRenavigator;

            _addNewJobCommand.PropertyChanged += AddNewMachineCommand_PropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                Job newJob = new Job
                {
                    JobName = _addNewJobCommand.JobName,
                    MachineNumber = _addNewJobCommand.MachineNumber,
                    JobLength = _addNewJobCommand.JobLength,
                    JobStartDate = _addNewJobCommand.JobStartDate,
                    JobEndDate = _addNewJobCommand.JobEndDate,
                    TotalProduction = _addNewJobCommand.TotalProduction
                };

                RegistrationResult registrationResult = await _authenticator.RegisterJob(newJob);

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
