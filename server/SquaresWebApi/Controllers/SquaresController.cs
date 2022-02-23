using Microsoft.AspNetCore.Mvc;
using SquaresWebApi.Dtos.SquareDtos;
using SquaresWebApi.Services;

namespace SquaresWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SquaresController : ControllerBase
    {
        private SquaresService _squaresService;

        public SquaresController(SquaresService squaresService)
        {
            _squaresService = squaresService;
        }

        [HttpPost]
        public IActionResult GetAll(PointsCollectionSquaresDto collectionDto)
        {
            try
            {
                return Ok(_squaresService.GetSquares(collectionDto));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
