namespace Subsetsix.Web.Client.Services;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> Get()
    {
        return await _httpClient.GetStringAsync("items.list");
    }
}