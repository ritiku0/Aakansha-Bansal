using Organisation.Domain.Services.AuthenticationServices;
using Organisation.WPF.State.Authenticators;
using Organisation.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Organisation.WPF.Commands
{
    public class EditCommand : AsyncCommandBase
    {

        private readonly IAuthenticator _authenticator;
        private readonly ProfileViewModel _profileViewModel;

        public EditCommand(ProfileViewModel profileViewModel, IAuthenticator authenticator)
        {
            _profileViewModel = profileViewModel;
            _authenticator = authenticator;
            _profileViewModel.PropertyChanged += PropertyViewModel_PropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return _profileViewModel.CanEdit && base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {

            try
            {
                RegistrationResult registrationResult = await _authenticator.Update(
                     _profileViewModel.Id,
                        _profileViewModel.OrganisationName,
                         _profileViewModel.Country,
                         _profileViewModel.Address,
                         _profileViewModel.Email,
                          _profileViewModel.PhoneNumber,
                       _profileViewModel.Password
                     );

                MessageBox.Show(string.Format("Details of Organisation {0} updated successfully", _profileViewModel.OrganisationName));
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void PropertyViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ProfileViewModel.CanEdit))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
