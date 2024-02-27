using Cgs.Leilao.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cgs.Leilao.API.Repositories
{
    public class CgsLeilaoDbContext : DbContext
    {
        public CgsLeilaoDbContext(DbContextOptions options): base (options) { }

        public DbSet<Auction> Auctions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Offer> Offers { get; set; }

    }
}
