using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ReadmeGen.DTOs
{
    public enum Status
    {
        Succes,
        Partial,
        Failed
    }
    public class FileValidationDto
    {
        public required List<string> ValidFiles {get; set;}
        public required List<string> InvalidFiles {get; set;}
        public required Status ValidationStatus {get; set;}
        
    }
}