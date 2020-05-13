using System.Collections.Generic;
using System.Threading.Tasks;
using WooliesX.DomainModel;
using WooliesX.Usecases.ServiceClients;

namespace WooliesX.Usecases
{
    public class ProductService : IProductService
    {
        private readonly IProductApiClient _productApiClient;
        private readonly IShopperHistoryApiClient _historyApiClient;

        public ProductService(IProductApiClient productApiClient, IShopperHistoryApiClient historyApiClient)
        {
            _productApiClient = productApiClient;
            _historyApiClient = historyApiClient;
        }

        public async Task<IEnumerable<Product>> GetSortedProducts(SortOption sortoption)
        {
            var products = await _productApiClient.GetProducts();

            if (sortoption == SortOption.Recommended)
            {
                var shopperHistory = await _historyApiClient.GetShopperHistory();

                return shopperHistory.SortProductsByPopularity(products);
            }

            return new ProductSorter(products).Sort(sortoption);
        }
    }
}
