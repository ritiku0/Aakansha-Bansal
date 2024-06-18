using Microsoft.AspNet.Identity;
using Organisation.Domain.Exceptions;
using Organisation.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Organisation.Domain.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAccountService _accountService;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationService(IAccountService accountService, IPasswordHasher passwordHasher)
        {
            _accountService = accountService;
            _passwordHasher = passwordHasher;
        }

        public async Task<User> Login(string username, string password)
        {
            User storedAccount = await _accountService.GetByUsername(username);

            if (storedAccount == null)
            {
                throw new UserNotFoundException(username);
            }

            PasswordVerificationResult passwordResult = _passwordHasher.VerifyHashedPassword(storedAccount.Password, password);

            if (passwordResult != PasswordVerificationResult.Success)
            {
                throw new InvalidPasswordException(username, password);
            }

            return storedAccount;
        }

        public async Task<RegistrationResult> Register(string username, string country, string address, string email, string phoneNumber, string password)
        {
            RegistrationResult result = RegistrationResult.Success;

            try
            {
                var emailAccount = await _accountService.GetByEmail(email);
                if (emailAccount != null)
                {
                    result = RegistrationResult.EmailAlreadyExists;
                }

                var usernameAccount = await _accountService.GetByUsername(username);
                if (usernameAccount != null)
                {
                    result = RegistrationResult.UsernameAlreadyExists;
                }

                if (result == RegistrationResult.Success)
                {
                    string hashedPassword = _passwordHasher.HashPassword(password);

                    User user = new User()
                    {
                        Email = email,
                        Username = username,
                        Country = country,
                        Address = address,
                        PhoneNumber = phoneNumber,
                        Password = hashedPassword
                    };

                    await _accountService.Create(user);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }


        public async Task<RegistrationResult> Update(int Id, string username, string country, string address, string email, string phoneNumber, string password)
        {
            RegistrationResult result = RegistrationResult.Success;

            try
            {
                User user = new User()
                {
                    Email = email,
                    Username = username,
                    Country = country,
                    Address = address,
                    PhoneNumber = phoneNumber,
                    Password = password
                };

                await _accountService.Update(Id, user);

            }
            catch (Exception ex)
            {
                result = RegistrationResult.PasswordsDoNotMatch;
                Console.WriteLine(ex.Message);
            }
            return result;
        }

    }
}
