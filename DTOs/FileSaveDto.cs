namespace ReadmeGen.DTOs
{
    public enum SaveStatus
    {
        Succes,
        Failed,
        Partial,
        Duplicate
    }
    public class FileSaveDto
    {
        public required int Id {get; set;}
        public required List<string> FileList {get; set;}
        public required SaveStatus SaveStatus {get; set;}
        public required List<string> Errors {get; set;}
    }
}