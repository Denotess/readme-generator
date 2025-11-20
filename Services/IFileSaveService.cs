using ReadmeGen.DTOs;

namespace ReadmeGen.Services
{
    public interface IFileSaveService
    {
        Task<FileSaveDto> SaveFiles(IFormFileCollection files, FileSaveDto dto);
    }   
}