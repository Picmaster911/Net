using Microsoft.EntityFrameworkCore;
using PhoneCatalog.DAL.Entities;
using System;

namespace PhoneCatalog.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<PhoneItem> PhoneItems { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)

        {
        }

    }
}
