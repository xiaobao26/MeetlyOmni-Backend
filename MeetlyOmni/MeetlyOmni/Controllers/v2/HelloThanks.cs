using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace MeetlyOmni.Controllers.v2
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class HelloThanks
    {
        [HttpGet]
        public string Get()
        {
            return "Hello Thanks";
        }
    }
}
