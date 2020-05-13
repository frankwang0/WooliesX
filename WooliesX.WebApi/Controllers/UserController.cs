using Microsoft.AspNetCore.Mvc;

namespace WooliesX.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var value = new { Name = "Frank Wang", Token = "03dd27f1-8b91-4428-a195-6e4b344c7a01" };

            return Ok(value);
        }
    }
}
