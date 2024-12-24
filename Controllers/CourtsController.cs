using BadmintonHub.Models;
using BadmintonHub.Services;
using Microsoft.AspNetCore.Mvc;

namespace BadmintonHub.Controllers
{
    [ApiController]
    [Route("/courts")]
    public class CourtsController : Controller
    {
        private readonly CourtService _courseService;

        public CourtsController()
        {
            _courseService = new CourtService();
        }

        // GET /courts
        [HttpGet]
        public IEnumerable<Court> GetCourts()
        {
            var courts = _courseService.GetCourts();
            return courts;
        }
    }
}
