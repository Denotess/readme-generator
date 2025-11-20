using Microsoft.AspNetCore.Http.HttpResults;
using ReadmeGen.DTOs;

namespace ReadmeGen.Services
{
    public class FileSaveService : IFileSaveService
    {
        public async Task<FileSaveDto> SaveFiles(IFormFileCollection files, FileSaveDto dto)
        {
            string basePath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
            Directory.CreateDirectory(basePath);
            string projectFolder = Path.Combine(basePath, dto.Id.ToString());
            Directory.CreateDirectory(projectFolder);

            int savedCount = 0;
            foreach (var file in files)
            {
                string filePath = Path.Combine(projectFolder, file.FileName);
                try
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    dto.FileList.Add(file.FileName);
                    savedCount++;
                }
                catch (Exception ex)
                {
                    dto.Errors.Add($"Failed to save {file.FileName}: {ex.Message}");
                }
            }

            if (savedCount == files.Count)
            {
                dto.SaveStatus = SaveStatus.Succes;
            }
            else if (savedCount > 0)
            {
                dto.SaveStatus = SaveStatus.Partial;
            }
            else
            {
                dto.SaveStatus = SaveStatus.Failed;
            }

            return dto;
        }
    }
}