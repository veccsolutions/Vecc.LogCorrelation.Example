using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Vecc.LogCorrelation.Example.Source.Services;

namespace Vecc.LogCorrelation.Example.Source.Controllers
{
    [Route("Do")]
    public class DoController : Controller
    {
        private readonly ILogger<DoController> _logger;
        private readonly TargetHeadersClient _targetClient;

        public DoController(ILogger<DoController> logger, TargetHeadersClient targetClient)
        {
            this._logger = logger;
            this._targetClient = targetClient;
        }

        [HttpGet("Something")]
        public async Task<IActionResult> Something()
        {
            this._logger.LogInformation("Doing something");
            
            var headers = await _targetClient.DumpAsync();

            return Ok(headers);
        }
    }
}
