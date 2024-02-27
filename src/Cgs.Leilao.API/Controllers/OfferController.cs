using Cgs.Leilao.API.Communication.Requests;
using Cgs.Leilao.API.Filters;
using Cgs.Leilao.API.UseCases.Offers.CreateOffer;
using Microsoft.AspNetCore.Mvc;

namespace Cgs.Leilao.API.Controllers
{
    [ServiceFilter(typeof(AutenticationUserAttribute))]
    public class OfferController : CgsLeilaoAuctionBaseController
    {
        [HttpPost]
        [Route("{itemId}")]       
        public IActionResult CreateOffer(
            [FromRoute] int itemId, 
            [FromBody] RequestCreateOfferJson request,
            [FromServices] CreateOfferUseCase useCase
            )
        {
            var resultId = useCase.Execute(itemId, request);
            return Created(string.Empty, resultId);
        }
    }
}
