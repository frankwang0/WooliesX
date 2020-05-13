using Microsoft.AspNetCore.Mvc;
using WooliesX.DomainModel.Trolley;
using WooliesX.Usecases;

namespace WooliesX.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    public class TrolleyTotalController : ControllerBase
    {
        private readonly ITrolleyValidator _trolleyValidator;

        public TrolleyTotalController(ITrolleyValidator trolleyValidator)
        {
            _trolleyValidator = trolleyValidator;
        }

        [HttpPost]
        public IActionResult Post([FromBody] ShoppingTrolley trolley)
        {
            if (!_trolleyValidator.Validate(trolley))
            {
                return BadRequest();
            }

            return Ok(trolley.CalculateTotal());
        }
    }
}
