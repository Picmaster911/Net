using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Movie> Movies { get; set; }

        DbSet<Session> Sessions { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        EntityEntry Remove(object ob);
        ValueTask<EntityEntry> AddAsync(object ob, CancellationToken cancellationToken = default);
    }
}

