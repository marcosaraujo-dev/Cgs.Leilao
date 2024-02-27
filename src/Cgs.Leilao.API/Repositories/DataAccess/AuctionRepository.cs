using Cgs.Leilao.API.Contracts;
using Cgs.Leilao.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cgs.Leilao.API.Repositories.DataAccess
{
    public class AuctionRepository: IAuctionRepository
    {
        private readonly CgsLeilaoDbContext _dbcontext;
        public AuctionRepository(CgsLeilaoDbContext dbContext) => _dbcontext = dbContext;

        public Auction? GetCurrent()
        {
            var today = DateTime.Now;
            return _dbcontext
               .Auctions
               .Include(auction => auction.Items)
               .FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);
        }
    }
}
