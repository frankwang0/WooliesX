using System.Collections.Generic;
using System.Threading.Tasks;
using WooliesX.DomainModel;

namespace WooliesX.Usecases.ServiceClients
{
    public interface IProductApiClient
    {
        public Task<IEnumerable<Product>> GetProducts();
    }
}