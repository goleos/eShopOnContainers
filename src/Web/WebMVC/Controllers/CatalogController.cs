namespace Microsoft.eShopOnContainers.WebMVC.Controllers;

public class CatalogController : Controller
{
    private ICatalogService _catalogSvc;

    private IOfferService _offerService;

    private readonly ILogger<CatalogService> _logger;



    public CatalogController(ICatalogService catalogSvc, IOfferService offerSvc, ILogger<CatalogService> logger)
    {
        _catalogSvc = catalogSvc;
        _offerService = offerSvc;
        _logger = logger;

    }


    public async Task<IActionResult> Index(int? BrandFilterApplied, int? TypesFilterApplied, int? page, [FromQuery] string errorMsg)
    {
        var itemsPage = 9;
        var catalog = await _catalogSvc.GetCatalogItems(page ?? 0, itemsPage, BrandFilterApplied, TypesFilterApplied);
        var offers = await _offerService.GetAllOffers();

        var catalogItemsWithOffers = new List<CatalogItem>();
        foreach (var catalogItem in catalog.Data)
        {
            var relevantOffers = offers.FindAll(offer =>  offer.CatalogItemID == catalogItem.Id);
            var offer = relevantOffers.FirstOrDefault();
            if (offer != null) {
                var offerpPrice = offer.OfferPrice;
                catalogItemsWithOffers.Add(new CatalogItem
                {
                    OfferPrice = offerpPrice,
                    Price = catalogItem.Price,
                    Description = catalogItem.Description,
                    PictureUri = catalogItem.PictureUri,
                    CatalogBrand = catalogItem.CatalogBrand,
                    CatalogType = catalogItem.CatalogType,
                    Id = catalogItem.Id,
                    CatalogBrandId = catalogItem.CatalogBrandId,
                    Name = catalogItem.Name,
                    CatalogTypeId = catalogItem.CatalogTypeId,
                }
                    );
            } else
            {
                catalogItemsWithOffers.Add(catalogItem);
            }
        }

        var vm = new IndexViewModel()
        {
            CatalogItems = catalogItemsWithOffers,
            Brands = await _catalogSvc.GetBrands(),
            Types = await _catalogSvc.GetTypes(),
            BrandFilterApplied = BrandFilterApplied ?? 0,
            TypesFilterApplied = TypesFilterApplied ?? 0,
            PaginationInfo = new PaginationInfo()
            {
                ActualPage = page ?? 0,
                ItemsPerPage = catalog.Data.Count,
                TotalItems = catalog.Count,
                TotalPages = (int)Math.Ceiling(((decimal)catalog.Count / itemsPage))
            }
        };

        vm.PaginationInfo.Next = (vm.PaginationInfo.ActualPage == vm.PaginationInfo.TotalPages - 1) ? "is-disabled" : "";
        vm.PaginationInfo.Previous = (vm.PaginationInfo.ActualPage == 0) ? "is-disabled" : "";

        ViewBag.BasketInoperativeMsg = errorMsg;

        return View(vm);
    }
}