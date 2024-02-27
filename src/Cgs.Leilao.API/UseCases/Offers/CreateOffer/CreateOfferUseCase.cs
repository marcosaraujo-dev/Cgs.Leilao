using Cgs.Leilao.API.Communication.Requests;
using Cgs.Leilao.API.Contracts;
using Cgs.Leilao.API.Entities;
using Cgs.Leilao.API.Repositories;
using Cgs.Leilao.API.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Cgs.Leilao.API.UseCases.Offers.CreateOffer
{
    public class CreateOfferUseCase
    {
        private readonly ILoggedUser _loggedUser;
        private readonly IOfferRepository _offerRepository;
        public CreateOfferUseCase(ILoggedUser loggedUser, IOfferRepository offerRepository)
        {
            _loggedUser = loggedUser;
            _offerRepository = offerRepository;
        }
        public int Execute(int itemId, RequestCreateOfferJson request)
        {
            var today = DateTime.Now;
            var user = _loggedUser.User();

            var offer = new Offer
            {
                CreatedOn = DateTime.Now,
                ItemId = itemId,
                Price = request.Price,
                UserId = user.Id,
            };
            try
            {

                _offerRepository.Add(offer);
            }
            catch (Exception ex)
            {
                return 0;
            }

            return offer.Id;

        }
    }
}
