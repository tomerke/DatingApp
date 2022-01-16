using Microsoft.EntityFrameworkCore;
using API.Entities;

namespace API.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions options) :base(options)
        {

        }

        public DbSet<AppUser> Name { get; set; }

        protected override void  OnModelCreating(ModelBuilder builder)
        {
            builder.Entity
        }
    }
}