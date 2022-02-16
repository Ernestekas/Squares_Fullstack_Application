using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SquaresWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointsCollectionController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }
    }
}
