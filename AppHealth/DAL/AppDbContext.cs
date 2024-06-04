using Microsoft.EntityFrameworkCore;
using Contracts;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DAL
{
    public class AppDbContext: DbContext, IApplicationDbContext
    {
        public DbSet <Person> Persons { get; set; }  
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public override EntityEntry Remove(object entity)
        {
            return base.Remove(entity);
        }

        public override ValueTask<EntityEntry> AddAsync(object entity, CancellationToken cancellationToken = default)
        {
            return base.AddAsync(entity, cancellationToken);
        }
    }
}
