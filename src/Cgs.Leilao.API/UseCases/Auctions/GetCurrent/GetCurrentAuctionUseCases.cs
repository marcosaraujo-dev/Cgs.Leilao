using Cgs.Leilao.API.Contracts;
using Cgs.Leilao.API.Entities;

namespace Cgs.Leilao.API.UseCases.Leiloes.GetCurrent
{
    public class GetCurrentAuctionUseCases
    {
        private readonly IAuctionRepository _repository;

        public GetCurrentAuctionUseCases(IAuctionRepository repository) => _repository = repository;

        public Auction? Execute()
        {
            return _repository.GetCurrent();
        }
    }
}
