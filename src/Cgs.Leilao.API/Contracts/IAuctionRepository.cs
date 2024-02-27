using Cgs.Leilao.API.Entities;

namespace Cgs.Leilao.API.Contracts
{
    public interface IAuctionRepository
    {
        public Auction? GetCurrent();
    }
}
