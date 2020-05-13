using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WooliesX.DomainModel;
using WooliesX.Usecases;

namespace WooliesX.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    public class SortController : ControllerBase
    {
        private readonly IProductService _productService;

        public SortController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] SortOption sortoption)
        {
            var products = await _productService.GetSortedProducts(sortoption);

            return Ok(products);
        }
    }
}
