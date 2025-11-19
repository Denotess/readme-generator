using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http.HttpResults;
using ReadmeGen.DTOs;

namespace ReadmeGen.Services
{
    public interface IFileValidationService
    {
        Task<bool> ValidateFiles(IFormFileCollection files, FileValidationDto dto);

    };
}