using System.Threading.Tasks;
using WooliesX.DomainModel;

namespace WooliesX.Usecases.ServiceClients
{
    public interface IShopperHistoryApiClient
    {
        public Task<ShopperHistory> GetShopperHistory();
    }
}