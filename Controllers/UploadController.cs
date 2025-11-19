using Microsoft.AspNetCore.Mvc;
using ReadmeGen.DTOs;

namespace ReadmeGen.Controllers
{
    [ApiController]
    public class UploadController : ControllerBase
    {
        [HttpPost("upload")]
        public async Task<IActionResult> Generate(IFormFileCollection files)
        {
            return Ok();
        }
    }
}