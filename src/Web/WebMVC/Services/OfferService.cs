
using System.Net.Http;

namespace Microsoft.eShopOnContainers.WebMVC.Services;

    public class OfferService: IOfferService
    {
    private readonly IOptions<AppSettings> _settings;
    private readonly HttpClient _httpClient;
    private readonly ILogger<CatalogService> _logger;

    private readonly string _remoteServiceBaseUrl;

    public OfferService(HttpClient httpClient, ILogger<CatalogService> logger, IOptions<AppSettings> settings)
    {
        _httpClient = httpClient;
        _settings = settings;
        _logger = logger;

        //TODO: replace this url with environment variable
        _remoteServiceBaseUrl = $"http://host.docker.internal:5201";
    }

    public async Task<List<OfferViewModel>> GetAllOffers()
    {
        var uri = API.Offer.GetAllOffers(_remoteServiceBaseUrl);

        var responseString = await _httpClient.GetStringAsync(uri);

        var offers = JsonSerializer.Deserialize<List<OfferViewModel>>(responseString, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        _logger.LogError($"Hello {JsonSerializer.Serialize(offers)}");

        return offers;

    }
}

