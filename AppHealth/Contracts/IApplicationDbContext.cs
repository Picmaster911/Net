using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Contracts
{
    public interface IApplicationDbContext
    {
        DbSet<Person> Persons { get; set; }
        Task<int> SaveChangesAsync (CancellationToken cancellationToken = default);

        EntityEntry Remove(object ob);
        ValueTask<EntityEntry> AddAsync(object ob, CancellationToken cancellationToken = default);
    }
}
