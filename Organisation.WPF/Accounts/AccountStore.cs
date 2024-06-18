using Organisation.Domain.Models;
using System;

namespace Organisation.WPF.Accounts
{
    public class AccountStore : IAccountStore
    {
        private User _currentAccount;
        public User CurrentAccount
        {
            get
            {
                return _currentAccount;
            }
            set
            {
                _currentAccount = value;
                StateChanged?.Invoke();
            }
        }

        public event Action StateChanged;

    }
}
