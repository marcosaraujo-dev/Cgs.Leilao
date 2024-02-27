using Cgs.Leilao.API.Entities;

namespace Cgs.Leilao.API.Contracts
{
    public interface IOfferRepository
    {
        public void Add(Offer offer);
    }
}
