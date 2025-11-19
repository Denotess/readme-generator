using ReadmeGen.DTOs;
namespace ReadmeGen.Services
{
    public class FileValidationService : IFileValidationService
    {
        public async Task<bool> ValidateFiles(IFormFileCollection file, FileValidationDto dto)
        {
            // List of allowed code file extensions
            var allowedExtensions = new HashSet<string>
            {
                ".cs", ".py", ".js", ".ts", ".java", ".cpp", ".c", ".rb", ".go", ".php", ".html", ".css", ".json", ".xml", ".md"
            };

            bool allValid = true;
            foreach (var f in file)
            {
                var ext = System.IO.Path.GetExtension(f.FileName).ToLowerInvariant();
                if (!allowedExtensions.Contains(ext))
                {
                    dto.InvalidFiles.Add(f.FileName);
                    allValid = false;
                }
                else{
                    dto.ValidFiles.Add(f.FileName);
                }
            }
            if (dto.ValidFiles.Count == 0)
            {
                dto.ValidationStatus = Status.Failed;
            }
            else if (dto.InvalidFiles.Count == 0){
                dto.ValidationStatus = Status.Succes;
            }
            else {
                dto.ValidationStatus = Status.Partial;
            }
            return allValid;
        }
        
    }
}