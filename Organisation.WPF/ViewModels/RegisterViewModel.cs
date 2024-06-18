using Organisation.WPF.Commands;
using Organisation.WPF.State.Authenticators;
using Organisation.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Organisation.WPF.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        private string _username;
        public string OrganisationName
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(OrganisationName));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        private string _country;
        public string Country
        {
            get
            {
                return _country;
            }
            set
            {
                _country = value;
                OnPropertyChanged(nameof(Country));
                OnPropertyChanged(nameof(CanRegister));
            }
        }
        private string _address;
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
                OnPropertyChanged(nameof(CanRegister));
            }
        }
        

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        public bool CanRegister => !string.IsNullOrEmpty(Email) &&
            !string.IsNullOrEmpty(OrganisationName) &&
            !string.IsNullOrEmpty(Password) &&
            !string.IsNullOrEmpty(Country);

        public ICommand RegisterCommand { get; }

        public ICommand ViewLoginCommand { get; }

        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        public RegisterViewModel(IAuthenticator authenticator, IRenavigator registerRenavigator, IRenavigator loginRenavigator)
        {
            ErrorMessageViewModel = new MessageViewModel();

            RegisterCommand = new RegisterCommand(this, authenticator, registerRenavigator);
            ViewLoginCommand = new RenavigateCommand(loginRenavigator);
        }

        public override void Dispose()
        {
            ErrorMessageViewModel.Dispose();

            base.Dispose();
        }
    }
}
