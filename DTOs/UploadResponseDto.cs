using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;

namespace ReadmeGen.DTOs
{
    public enum CurrentStatus
    {
        Accepted,
        Queued,
        Processing,
        Completed,
        Failed,
        Invalid,
        Timeout,
        Duplicate
    }
    public class UploadResponseDto
    {
        public required int Id {get; set;}
        public required CurrentStatus Status {get; set;}
        public required DateTime CreatedAt {get; set;}
        public required string Message {get; set;}
         
    }
}