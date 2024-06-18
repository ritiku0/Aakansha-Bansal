using Microsoft.EntityFrameworkCore;
using Organisation.Domain.Models;
using Organisation.Domain.Services;
using Organisation.EntityFramework.Services.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Organisation.EntityFramework.Services
{
    public class AccountDataService : IAccountService
    {
        private readonly OrganisationDbContextFactory _contextFactory;
        private readonly NonQueryDataService<User> _nonQueryDataService;

        public AccountDataService(OrganisationDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<User>(contextFactory);
        }

        public async Task<User> Create(User entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<User> Get(int id)
        {
            using (OrganisationDbContext context = _contextFactory.CreateDbContext())
            {
                User entity = await context.Users
                    .Include(a => a.Username)                   
                    .FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            using (OrganisationDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<User> entities = await context.Users
                    .Include(a => a.Username)                   
                    .ToListAsync();
                return entities;
            }
        }

        public async Task<User> GetByEmail(string email)
        {
            using (OrganisationDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Users                                   
                    .FirstOrDefaultAsync(a => a.Email == email);
            }
        }

        public async Task<User> GetByUsername(string username)
        {
            using (OrganisationDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Users                                    
                    .FirstOrDefaultAsync(a => a.Username == username);
            }
        }

        public async Task<User> Update(int id, User entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
    }
}
