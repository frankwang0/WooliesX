using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WooliesX.DomainModel;
using System.IO;

namespace WooliesX.Usecases.ServiceClients
{
    public class ProductApiClient : IProductApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly ServiceApiConfig _apiConfig;

        public ProductApiClient(HttpClient httpClient, ServiceApiConfig apiConfig)
        {
            _httpClient = httpClient;
            _apiConfig = apiConfig;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var uri = $"{_apiConfig.BaseUrl}/products?token={_apiConfig.Token}";

            // Todo: add some logging as we are crossing system boundary

            var response = await _httpClient.GetAsync(new Uri(uri));

            var contentStream = await response.Content.ReadAsStreamAsync();
            using var jsonReader = new JsonTextReader(new StreamReader(contentStream));

            return new JsonSerializer().Deserialize<IEnumerable<Product>>(jsonReader);
        }
    }
}
