using Microsoft.AspNetCore.Mvc;
using ReadmeGen.DTOs;
using ReadmeGen.Services;

namespace ReadmeGen.Controllers
{
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IFileValidationService _fileValidationService;
        public UploadController(IFileValidationService fileValidationService)
        {
            _fileValidationService = fileValidationService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Generate(IFormFileCollection files, FileValidationDto dto)
        {
            bool isValid = await _fileValidationService.ValidateFiles(files, dto);
            if (!isValid)
            {
                return BadRequest(dto);
            }
            return Ok();
        }
    }
}