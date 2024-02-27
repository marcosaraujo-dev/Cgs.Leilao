using Cgs.Leilao.API.Entities;
using Cgs.Leilao.API.UseCases.Leiloes.GetCurrent;
using Microsoft.AspNetCore.Mvc;

namespace Cgs.Leilao.API.Controllers
{

    public class AuctionController : CgsLeilaoAuctionBaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
        [ProducesResponseType( StatusCodes.Status204NoContent)]
        public IActionResult GetCurrentLeilao([FromServices] GetCurrentAuctionUseCases useCase)
        {
           
            var  result = useCase.Execute();

            if (result is null)  return NoContent();

            return Ok(result);
        }
    }
}
