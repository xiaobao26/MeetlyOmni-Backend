using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace MeetlyOmni.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class HelloWorld : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello Thanks");
        }
    }
}
