using Dyplom.Data.Entites.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Dyplom.Data.Context
{
    public class MyContext : IdentityDbContext<ApplicationUser>
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }


    }
}
