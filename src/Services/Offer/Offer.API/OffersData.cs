namespace Offer.API
{
    public class OffersData
    {
        private List<OfferItem> OffersArray = new List<OfferItem>();

        public OffersData() {
            OfferItem offer1 = new OfferItem { CatalogItemID = 2, Id = 1, OfferPrice = 6.50M };

            OfferItem offer2 = new OfferItem { CatalogItemID = 4, Id = 2, OfferPrice = 10.00M };
            OfferItem offer3 = new OfferItem { CatalogItemID = 3, Id = 2, OfferPrice = 5.50M };

            OffersArray.Add(offer1);
            OffersArray.Add(offer2);
            OffersArray.Add(offer3);
        }

        public List<OfferItem> GetOfferItems()
        {
            return OffersArray;
        }
    }
}
