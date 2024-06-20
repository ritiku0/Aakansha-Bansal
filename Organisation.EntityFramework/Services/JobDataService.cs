using Microsoft.EntityFrameworkCore;
using Organisation.Domain.Models;
using Organisation.Domain.Services;
using Organisation.EntityFramework.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organisation.EntityFramework.Services
{   
    public class JobDataService : IJobDataService
    {
        private readonly OrganisationDbContextFactory _contextFactory;
        private readonly NonQueryDataService<Job> _nonQueryDataService;

        public JobDataService(OrganisationDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<Job>(contextFactory);
        }

        public async Task<Job> Create(Job entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<Job> Get(int id)
        {
            using (OrganisationDbContext context = _contextFactory.CreateDbContext())
            {
                Job entity = await context.Jobs
                    .FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<Job>> GetAll()
        {
            using (OrganisationDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Job> entities = await context.Jobs
                    .ToListAsync();
                return entities;
            }
        }

        public async Task<Job> Update(int id, Job entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
    }
}
