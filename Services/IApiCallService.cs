using ReadmeGen.DTOs;
namespace ReadmeGen.Services
{
    public interface IApiCallService
    {
        Task<string> CallApiAsync(ApiCallDto dto);

    };
}