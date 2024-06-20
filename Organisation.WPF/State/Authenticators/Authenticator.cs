using Organisation.Domain.Models;
using Organisation.Domain.Services.AuthenticationServices;
using Organisation.WPF.Accounts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Organisation.WPF.State.Authenticators
{
    public class Authenticator : IAuthenticator
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IAccountStore _accountStore;

        public Authenticator(IAuthenticationService authenticationService, IAccountStore accountStore)
        {
            _authenticationService = authenticationService;
            _accountStore = accountStore;
        }

        public User CurrentAccount
        {
            get
            {
                return _accountStore.CurrentAccount;
            }
            private set
            {
                _accountStore.CurrentAccount = value;
                StateChanged?.Invoke();
            }
        }

        public bool IsLoggedIn => CurrentAccount != null;

        public event Action StateChanged;

        public async Task Login(string username, string password)
        {
            CurrentAccount = await _authenticationService.Login(username, password);
        }

        public void Logout()
        {
            CurrentAccount = null;
        }

        public async Task<RegistrationResult> Register(string username, string country, string address, string email, string phoneNumber, string password)
        {
            return await _authenticationService.Register(username, country, address, email, phoneNumber, password);
        }

        public async Task<RegistrationResult> RegisterMachine(Machine entity)
        {
            return await _authenticationService.RegisterEntity(entity);
        }

        public async Task<IEnumerable<Machine>> FetchMachines()
        {
            return await _authenticationService.FetchMachines();
        }
        

        public async Task<RegistrationResult> Update(int Id, string username, string country, string address, string email, string phoneNumber, string password)
        {
            return await _authenticationService.Update(Id, username, country, address, email, phoneNumber, password);
        }

        public async Task<Machine> UpdateMachine(Machine machine)
        {
            return await _authenticationService.UpdateMachine(machine);
        }

        public async Task<bool> DeleteMachine(Machine machine)
        {
            return await _authenticationService.DeleteMachine(machine);
        }
        
    }
}
