using System.Text;
using System.Text.Json;

namespace KanzwayCron.Repositories;

public class HttpRequestRepository : IHttpRequestRepository
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSetting;
    private readonly IConfiguration _configuration;
    
    public HttpRequestRepository(IConfiguration configuration)
    {
        _httpClient = new HttpClient();
        _jsonSetting = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        _configuration = configuration;
    }

    public void Post(object model)
    {
        var apiUrl = _configuration.GetValue<string>("KanzwaySetting:KanzApiUrl");

        var json = JsonSerializer.Serialize(model, _jsonSetting);

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = _httpClient.PostAsync($"{apiUrl}v1/orders/pendings", content).GetAwaiter().GetResult();

        response.EnsureSuccessStatusCode();
    }
}