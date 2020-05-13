using System.Collections.Generic;
using System.Linq;

namespace WooliesX.DomainModel
{
    public class ProductSorter
    {
        private readonly IEnumerable<Product> _products;

        public ProductSorter(IEnumerable<Product> products)
        {
            _products = products;
        }

        public IEnumerable<Product> Sort(SortOption sortOption)
        {
            switch (sortOption)
            {
                case SortOption.Ascending:
                    return _products.OrderBy(x => x.Name);

                case SortOption.Descending:
                    return _products.OrderByDescending(x => x.Name);

                case SortOption.Low:
                    return _products.OrderBy(x => x.Price);

                default: // sort by price in descending order by default
                    return _products.OrderByDescending(x => x.Price);
            }
        }
    }
}
