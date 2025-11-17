using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using ReadmeGen.DTOs;


namespace ReadmeGen.Services
{
    public class ApiCallService : IApiCallService
    {
        private static HttpClient sharedClient = new()
        {
            BaseAddress = new Uri("https://openrouter.ai/api/v1/chat/completions"),
        };

        public async Task<string> CallApiAsync(ApiCallDto dto)
        {
            string ApiKey = Environment.GetEnvironmentVariable("ApiKey") ?? "";
            var request = new HttpRequestMessage(HttpMethod.Post, "");
            var body = new
            {
                model = "tngtech/deepseek-r1t2-chimera:free",
                messages = new[]
                {
                    new {
                        role = "user",
                        content = dto.Content
                        }
                }

            };
            string jsonBody = JsonSerializer.Serialize(body);
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", ApiKey);
            request.Content = new StringContent(jsonBody, System.Text.Encoding.UTF8, "application/json");
            var response = await sharedClient.SendAsync(request);
            string responseContent = await response.Content.ReadAsStringAsync();

            return responseContent;
        }
    }
};