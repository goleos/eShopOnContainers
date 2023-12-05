using Microsoft.AspNetCore.Mvc;

namespace Offer.API.Controllers
{
    [ApiController]
    [Route("offers")]
    public class OffersController : ControllerBase
    {

        private readonly ILogger<OffersController> _logger;

        private OffersData _data = new OffersData();

        public OffersController(ILogger<OffersController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetOffers")]
        public IEnumerable<OfferItem> Get()
        {

            return _data.GetOfferItems();
        }

    }
}
