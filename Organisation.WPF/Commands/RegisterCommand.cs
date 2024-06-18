using Organisation.Domain.Services.AuthenticationServices;
using Organisation.WPF.State.Authenticators;
using Organisation.WPF.State.Navigators;
using Organisation.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Organisation.WPF.Commands
{
    public class RegisterCommand : AsyncCommandBase
    {
        private readonly RegisterViewModel _registerViewModel;
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _registerRenavigator;

        public RegisterCommand(RegisterViewModel registerViewModel, IAuthenticator authenticator, IRenavigator registerRenavigator)
        {
            _registerViewModel = registerViewModel;
            _authenticator = authenticator;
            _registerRenavigator = registerRenavigator;

            _registerViewModel.PropertyChanged += RegisterViewModel_PropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return _registerViewModel.CanRegister && base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _registerViewModel.ErrorMessage = string.Empty;

            try
            {
                RegistrationResult registrationResult = await _authenticator.Register(
                        _registerViewModel.OrganisationName,
                         _registerViewModel.Country,
                         _registerViewModel.Address,
                         _registerViewModel.Email,
                          _registerViewModel.PhoneNumber,
                       _registerViewModel.Password
                     );

                switch (registrationResult)
                {
                    case RegistrationResult.Success:
                        _registerRenavigator.Renavigate();
                        break;
                    case RegistrationResult.PasswordsDoNotMatch:
                        _registerViewModel.ErrorMessage = "Password does not match confirm password.";
                        break;
                    case RegistrationResult.EmailAlreadyExists:
                        _registerViewModel.ErrorMessage = "An account for this email already exists.";
                        break;
                    case RegistrationResult.UsernameAlreadyExists:
                        _registerViewModel.ErrorMessage = "An account for this username already exists.";
                        break;
                    default:
                        _registerViewModel.ErrorMessage = "Registration failed.";
                        break;
                }
            }
            catch (Exception)
            {
                _registerViewModel.ErrorMessage = "Registration failed.";
            }
        }

        private void RegisterViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(RegisterViewModel.CanRegister))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
