using Organisation.Domain.Models;
using Organisation.Domain.Exceptions;
using Organisation.Domain.Services.AuthenticationServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Organisation.WPF.State.Authenticators
{
    public interface IAuthenticator
    {
        User CurrentAccount { get; }
        bool IsLoggedIn { get; }

        event Action StateChanged;

        /// <summary>
        /// Register a new user.
        /// </summary>
        /// <param name="username">The user's name.</param>
        /// <param name="country">The user's country.</param>
        /// <param name="address">The user's country.</param>
        /// <param name="email">The user's email.</param>
        /// <param name="phoneNumber">The user's name.</param>
        /// <param name="password">The user's password.</param>       
        /// <returns>The result of the registration.</returns>
        /// <exception cref="Exception">Thrown if the registration fails.</exception>
        Task<RegistrationResult> Register(string username, string country, string address, string email, string phoneNumber, string password);

        Task<RegistrationResult> RegisterMachine(Machine machine);

        Task<IEnumerable<Machine>> FetchMachines();

        Task<IEnumerable<Job>> FetchJobs();

        /// <summary>
        /// Login to the application.
        /// </summary>
        /// <param name="username">The user's name.</param>
        /// <param name="password">The user's password.</param>
        /// <exception cref="UserNotFoundException">Thrown if the user does not exist.</exception>
        /// <exception cref="InvalidPasswordException">Thrown if the password is invalid.</exception>
        /// <exception cref="Exception">Thrown if the login fails.</exception>
        Task Login(string username, string password);

        /// <summary>
        /// Update a new user.
        /// </summary>
        /// <param name="username">The user's name.</param>
        /// <param name="country">The user's country.</param>
        /// <param name="address">The user's country.</param>
        /// <param name="email">The user's email.</param>
        /// <param name="phoneNumber">The user's name.</param>
        /// <param name="password">The user's password.</param>       
        /// <returns>The result of the registration.</returns>
        /// <exception cref="Exception">Thrown if the registration fails.</exception>
        Task<RegistrationResult> Update(int Id, string username, string country, string address, string email, string phoneNumber, string password);

        Task<Machine> UpdateMachine(Machine machine);

        Task<bool> DeleteMachine(Machine machine);

        Task<Job> UpdateJob(Job job);

        Task<bool> DeleteJob(Job job);

        Task<RegistrationResult> RegisterJob(Job machine);

        void Logout();
    }
}
