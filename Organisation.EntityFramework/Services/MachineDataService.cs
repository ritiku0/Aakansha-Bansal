using Microsoft.EntityFrameworkCore;
using Organisation.Domain.Models;
using Organisation.Domain.Services;
using Organisation.EntityFramework.Services.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Organisation.EntityFramework.Services
{
    public class MachineDataService : IMachineDataService
    {
        private readonly OrganisationDbContextFactory _contextFactory;
        private readonly NonQueryDataService<Machine> _nonQueryDataService;

        public MachineDataService(OrganisationDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<Machine>(contextFactory);
        }

        public async Task<Machine> Create(Machine entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<Machine> Get(int id)
        {
            using (OrganisationDbContext context = _contextFactory.CreateDbContext())
            {
                Machine entity = await context.Machines
                    .FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<Machine>> GetAll()
        {
            using (OrganisationDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Machine> entities = await context.Machines                    
                    .ToListAsync();
                return entities;
            }
        }

        public async Task<Machine> Update(int id, Machine entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
    }

}
