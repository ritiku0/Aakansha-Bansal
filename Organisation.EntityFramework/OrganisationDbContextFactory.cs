using Microsoft.EntityFrameworkCore;
using System;

namespace Organisation.EntityFramework
{
    public class OrganisationDbContextFactory
    {
        private readonly Action<DbContextOptionsBuilder> _configureDbContext;

        public OrganisationDbContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
        {
            _configureDbContext = configureDbContext;
        }

        public OrganisationDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<OrganisationDbContext> options = new DbContextOptionsBuilder<OrganisationDbContext>();

            _configureDbContext(options);

            return new OrganisationDbContext(options.Options);
        }
    }
}
