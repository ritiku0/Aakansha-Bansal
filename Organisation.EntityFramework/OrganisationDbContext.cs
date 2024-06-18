using Microsoft.EntityFrameworkCore;
using Organisation.Domain.Models;

namespace Organisation.EntityFramework
{
    public class OrganisationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Machine> Machines { get; set; }

        public OrganisationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}

