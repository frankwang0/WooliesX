using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WooliesX.DomainModel;

namespace WooliesX.Usecases.ServiceClients
{
    public class ShopperHistoryApiClient : IShopperHistoryApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly ServiceApiConfig _apiConfig;

        public ShopperHistoryApiClient(HttpClient httpClient, ServiceApiConfig apiConfig)
        {
            _httpClient = httpClient;
            _apiConfig = apiConfig;
        }

        public async Task<ShopperHistory> GetShopperHistory()
        {
            var uri = $"{_apiConfig.BaseUrl}/shopperhistory?token={_apiConfig.Token}";

            // Todo: add some logging as we are crossing system boundary

            var response = await _httpClient.GetAsync(new Uri(uri));

            var contentStream = await response.Content.ReadAsStreamAsync();
            using var jsonReader = new JsonTextReader(new StreamReader(contentStream));

            var orders = new JsonSerializer().Deserialize<IEnumerable<Order>>(jsonReader);

            return new ShopperHistory(orders);
        }
    }
}
