using Microsoft.AspNet.Identity;
using Organisation.Domain.Exceptions;
using Organisation.Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organisation.Domain.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAccountService _accountService;
        private readonly IMachineDataService _machineDataService;
        private readonly IJobDataService _jobDataService;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationService(IAccountService accountService, IPasswordHasher passwordHasher, IMachineDataService machineDataService, IJobDataService jobDataService)
        {
            _accountService = accountService;
            _passwordHasher = passwordHasher;
            _machineDataService = machineDataService;
            _jobDataService = jobDataService;
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

        public async Task<RegistrationResult> RegisterEntity(Machine machine)
        {
            RegistrationResult result = RegistrationResult.Success;
            try
            {
                await _machineDataService.Create(machine);
            }
            catch (Exception ex)
            {
                result = RegistrationResult.Fail;
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


        public async Task<Machine> UpdateMachine(Machine machine)
        {
            try
            {
                await _machineDataService.Update(machine.Id, machine);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return default(Machine);
        }

        public async Task<bool> DeleteMachine(Machine machine)
        {
            try
            {
                await _machineDataService.Delete(machine.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return default;
        }

        public async Task<IEnumerable<Machine>> FetchMachines()
        {
            try
            {
                return await _machineDataService.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Enumerable.Empty<Machine>();
        }

        public async Task<IEnumerable<Job>> FetchJobs()
        {
            try
            {
                return await _jobDataService.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Enumerable.Empty<Job>();
        }

        public async Task<Job> UpdateJob(Job job)
        {
            try
            {
                await _jobDataService.Update(job.Id, job);
              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return default(Job);
        }

        public async Task<bool> DeleteJob(Job job)
        {
            try
            {
                await _jobDataService.Delete(job.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return default;
        }

        public async Task<RegistrationResult> RegisterJob(Job job)
        {
            RegistrationResult result = RegistrationResult.Success;
            try
            {
                await _jobDataService.Create(job);
            }
            catch (Exception ex)
            {
                result = RegistrationResult.Fail;
                Console.WriteLine(ex.Message);
            }
            return result;
        }

    }
}
