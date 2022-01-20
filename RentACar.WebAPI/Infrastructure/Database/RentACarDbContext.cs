using RentACar.WebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace RentACar.WebAPI.Infrastructure.Database
{
    public class RentACarDbContext : DbContext
    {
        public RentACarDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }
    }
}
