using Cgs.Leilao.API.Contracts;
using Cgs.Leilao.API.Entities;

namespace Cgs.Leilao.API.Repositories.DataAccess
{
    public class OfferRepository: IOfferRepository
    {
        private readonly CgsLeilaoDbContext _dbcontext;
        public OfferRepository(CgsLeilaoDbContext dbContext) => _dbcontext = dbContext;

        public void Add(Offer offer)
        {
            _dbcontext.Offers.Add(offer);

            _dbcontext.SaveChanges();
        }
    }
}
