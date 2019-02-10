using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Vecc.LogCorrelation.Example.Target.Controllers
{
    [Route("Headers")]
    public class HeadersController : Controller
    {
        private readonly ILogger<HeadersController> _logger;

        public HeadersController(ILogger<HeadersController> logger)
        {
            this._logger = logger;
        }

        [HttpGet("Dump")]
        public IActionResult Dump()
        {
            this._logger.LogInformation("Dumping Headers");

            return Ok(Request.Headers);
        }
    }
}
