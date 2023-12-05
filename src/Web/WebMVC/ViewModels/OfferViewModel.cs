namespace Microsoft.eShopOnContainers.WebMVC.ViewModels;
    public record OfferViewModel
    {
            public int Id { get; set; }

            public int CatalogItemID { get; set; }

            public decimal OfferPrice { get; set; }

        }
