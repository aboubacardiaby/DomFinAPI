using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace DomFinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        [HttpGet(Name = "GetPerson")]
        public IActionResult Get()
        {
            return Ok(new
            {
                id = 1,
                name = "John Doe",
                age = 30,
                address = "123 Main"

            });
        }
    }
}
