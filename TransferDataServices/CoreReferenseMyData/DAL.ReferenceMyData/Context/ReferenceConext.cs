using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreReferenceMyData.Enteties.Enteties;

namespace DAL.ReferenceMyData.Context
{
    public class ReferenceConext : DbContext
    {
        public ReferenceConext(DbContextOptions<ReferenceConext> options) : base(options) { }
        public virtual DbSet <SubscribeFilm> SubscribeFilms { get; set; }
    }
}
