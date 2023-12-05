namespace Microsoft.eShopOnContainers.WebMVC.Controllers;

public class OffersController : Controller
{
    private IOfferService _offerService;

    public OffersController(IOfferService offerSvc) =>
        _offerService = offerSvc;

    public async Task<IActionResult> Index()
    {
        var offers = await _offerService.GetAllOffers();
        var vm = new OfferViewModel()
        {
            Id = offers[0].Id,
            CatalogItemID = offers[0].CatalogItemID,
            OfferPrice = offers[0].OfferPrice,
        };

        return View(vm);
    }
}