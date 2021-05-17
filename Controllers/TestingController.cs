using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace iread_api_gateway_ms.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestingController : ControllerBase
    {
         // GET: Testing
        [HttpGet]
        public async Task<IActionResult> GetMsg()
        {
            return Ok($"Hellow from api gateway");
        }
    }
}
