using System.Collections.Generic;
using System.Linq;

namespace WooliesX.DomainModel
{
    public class ShopperHistory
    {
        private readonly IEnumerable<Order> _orders;

        public ShopperHistory(IEnumerable<Order> orders)
        {
            _orders = orders;
        }

        public IEnumerable<Product> SortProductsByPopularity(IEnumerable<Product> products)
        {
            var productPopularity = CalculatePopularity();

            return SortProducts(productPopularity, products);
        }

        public Dictionary<string, ProductPopularity> CalculatePopularity()
        {
            var popularity = new Dictionary<string, ProductPopularity>();

            foreach (var product in _orders.SelectMany(x => x.Products))
            {
                if (popularity.TryGetValue(product.Name, out ProductPopularity stats))
                {
                    // Todo: calculate popularity based on quantity sold.
                    // Check with business how the popularity should be calculated.

                    stats.QuantitySold += product.Quantity;
                    popularity[product.Name] = stats;
                }
                else
                {
                    var newStats = new ProductPopularity() { ProductName = product.Name, QuantitySold = product.Quantity };
                    popularity.Add(product.Name, newStats);
                }
            }

            return popularity;
        }

        private IEnumerable<Product> SortProducts(Dictionary<string, ProductPopularity> popularity, IEnumerable<Product> products)
        {
            var sortedProducts = from p in products
                                 join s in popularity.Values on p.Name equals s.ProductName
                                 orderby s.QuantitySold descending
                                 select p;

            return sortedProducts;
        }
    }
}
