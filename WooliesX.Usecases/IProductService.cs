using System.Collections.Generic;
using System.Threading.Tasks;
using WooliesX.DomainModel;

namespace WooliesX.Usecases
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetSortedProducts(SortOption sortoption);
    }
}