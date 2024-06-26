﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Organisation.Domain.Models;

namespace Organisation.Domain.Services.AuthenticationServices
{
    public enum RegistrationResult
    {
        Success,
        PasswordsDoNotMatch,
        EmailAlreadyExists,
        UsernameAlreadyExists,
        Fail
    }

    public interface IAuthenticationService
    {
        /// <summary>
        /// Register a new user.
        /// </summary>
        /// <param name="email">The user's email.</param>
        /// <param name="username">The user's name.</param>
        /// <param name="password">The user's password.</param>
        /// <param name="confirmPassword">The user's confirmed password.</param>
        /// <returns>The result of the registration.</returns>
        /// <exception cref="Exception">Thrown if the registration fails.</exception>
        Task<RegistrationResult> Register(string username, string country, string address, string email, string phoneNumber, string password);

        /// <summary>
        /// Get an account for a user's credentials.
        /// </summary>
        /// <param name="username">The user's name.</param>
        /// <param name="password">The user's password.</param>
        /// <returns>The account for the user.</returns>
        /// <exception cref="UserNotFoundException">Thrown if the user does not exist.</exception>
        /// <exception cref="InvalidPasswordException">Thrown if the password is invalid.</exception>
        /// <exception cref="Exception">Thrown if the login fails.</exception>
        Task<User> Login(string username, string password);

        /// <summary>
        /// Register a new user.
        /// </summary>
        /// <param name="email">The user's email.</param>
        /// <param name="username">The user's name.</param>
        /// <param name="password">The user's password.</param>
        /// <param name="confirmPassword">The user's confirmed password.</param>
        /// <returns>The result of the registration.</returns>
        /// <exception cref="Exception">Thrown if the registration fails.</exception>
        Task<RegistrationResult> Update(int Id, string username, string country, string address, string email, string phoneNumber, string password);

        Task<Machine> UpdateMachine(Machine machine);

        Task<bool> DeleteMachine(Machine machine);

        /// <summary>
        /// Register a new user.
        /// </summary>       
        /// <param name="entity">The user's entity.</param>
        /// <returns>The result of the registration.</returns>
        /// <exception cref="Exception">Thrown if the registration fails.</exception>
        Task<RegistrationResult> RegisterEntity(Machine machine);

        /// <summary>
        /// Register a new machine.     
        Task<IEnumerable<Machine>> FetchMachines();

        /// <summary>
        /// Fetch Jobs     
        Task<IEnumerable<Job>> FetchJobs();

        Task<Job> UpdateJob(Job machine);

        Task<bool> DeleteJob(Job machine);


        /// <summary>
        /// Register a new user.
        /// </summary>       
        /// <param name="entity">The user's entity.</param>
        /// <returns>The result of the registration.</returns>
        /// <exception cref="Exception">Thrown if the registration fails.</exception>
        Task<RegistrationResult> RegisterJob(Job machine);

    }
}
