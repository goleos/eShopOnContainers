namespace Microsoft.eShopOnContainers.WebMVC.Services;

    public interface IOfferService
    {
        Task<List<OfferViewModel>> GetAllOffers();
    }

