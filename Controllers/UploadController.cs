using Microsoft.AspNetCore.Mvc;
using ReadmeGen.DTOs;
using ReadmeGen.Services;

namespace ReadmeGen.Controllers
{
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IFileValidationService _fileValidationService;
        private readonly IFileSaveService _fileSaveService;
        public UploadController(IFileValidationService fileValidationService, IFileSaveService fileSaveService)
        {
            _fileValidationService = fileValidationService;
            _fileSaveService = fileSaveService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Generate([FromForm]IFormFileCollection files, FileValidationDto validationDto, FileSaveDto saveDto)
        {
            bool isValid = await _fileValidationService.ValidateFiles(files, validationDto);
            if (!isValid)
            {
                return BadRequest(validationDto);
            }
            await _fileSaveService.SaveFiles(files, saveDto);
                if (saveDto.SaveStatus == SaveStatus.Failed)
            {
                return BadRequest(saveDto);
            }
            return Ok( new {validation = validationDto, save = saveDto});
        }
    }
}