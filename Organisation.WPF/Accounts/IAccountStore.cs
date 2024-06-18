using Organisation.Domain.Models;
using System;

namespace Organisation.WPF.Accounts
{
    public interface IAccountStore
    {
        User CurrentAccount { get; set; }
        event Action StateChanged;
    }
}
