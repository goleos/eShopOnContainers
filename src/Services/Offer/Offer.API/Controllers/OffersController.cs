using Microsoft.AspNetCore.Mvc;

namespace Offer.API.Controllers
{
    [ApiController]
    [Route("offers")]
    public class OffersController : ControllerBase
    {

        private readonly OfferItem offer1 = new OfferItem { CatalogItemID = 2, Id = 1, OfferPrice = 6.50M };
        private readonly OfferItem offer2 = new OfferItem { CatalogItemID = 4, Id = 2, OfferPrice = 6.50M };

        private List<OfferItem> OffersArray = new List<OfferItem>();

        private readonly ILogger<OffersController> _logger;

        public OffersController(ILogger<OffersController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetOffers")]
        public IEnumerable<OfferItem> Get()
        {
            OffersArray.Add(offer1);
            OffersArray.Add(offer2);
            return OffersArray;
        }
    }
}
