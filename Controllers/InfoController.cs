using BadmintonHub.Models;
using BadmintonHub.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BadmintonHub.Controllers
{
    [ApiController]
    [Route("api/v1/info")]
    public class InfoController : ControllerBase
    {
        private readonly IInfoService _infoService;

        public InfoController(IInfoService infoService)
        {
            _infoService = infoService;
        }

        // GET /info
        [HttpGet]
        public async Task<ActionResult<Info>> GetCustomersAsync()
        {
            var results = await _infoService.GetInfoAsync();
            return Ok(results);
        }
    }
}
