using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Tree;
using ReadmeGen.DTOs;
using ReadmeGen.Services;
using Sprache;

namespace ReadmeGen.Controllers
{
    [ApiController]
    [Route("input")]
    public class InputController : ControllerBase
    {
        private readonly IApiCallService _apiCallService;
        public InputController(IApiCallService apiCallService)
        {
            _apiCallService = apiCallService;
        }
        [HttpPost("generate")]
        public async Task<IActionResult> Generate([FromBody] ApiCallDto dto)
        {
            string content = await _apiCallService.CallApiAsync(dto);
            /* using (JsonDocument document = JsonDocument.Parse(content))
            {
                JsonElement root = document.RootElement;
                string response = root.GetProperty("content").GetString() ?? "";
                return Ok(new { response });
            }; */
            
                
            return Ok(new { content });
        }
    }
}