using Organisation.WPF.Commands;
using Organisation.WPF.State.Authenticators;
using System.Windows.Input;

namespace Organisation.WPF.ViewModels
{
    public class ProfileViewModel : ViewModelBase
    {
        private IAuthenticator _authenticator;
        public ProfileViewModel(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
            EditCommand = new EditCommand(this, authenticator);
            SetInitialUserDetails();

        }


        private void SetInitialUserDetails()
        {
            _id = _authenticator.CurrentAccount.Id;
            _email = _authenticator.CurrentAccount.Email;
            _username = _authenticator.CurrentAccount.Username;
            _country = _authenticator.CurrentAccount.Country;
            _address = _authenticator.CurrentAccount.Address;
            _password = _authenticator.CurrentAccount.Password;
            _phoneNumber = _authenticator.CurrentAccount.PhoneNumber;
        }

        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
                OnPropertyChanged(nameof(CanEdit));
            }
        }
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
                OnPropertyChanged(nameof(CanEdit));
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
                OnPropertyChanged(nameof(CanEdit));
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
                OnPropertyChanged(nameof(CanEdit));
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
                OnPropertyChanged(nameof(CanEdit));
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
                OnPropertyChanged(nameof(CanEdit));
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
                OnPropertyChanged(nameof(CanEdit));
            }
        }

        public bool CanEdit => !string.IsNullOrEmpty(Email) &&
            !string.IsNullOrEmpty(OrganisationName) &&
            !string.IsNullOrEmpty(Password) &&
            !string.IsNullOrEmpty(Country) && !string.IsNullOrEmpty(Address) && !string.IsNullOrEmpty(PhoneNumber);

        public ICommand EditCommand { get; }
       

    }
}
