using Subsetsix.Api.Common;
using System.Net.Http.Json;

namespace Subsetsix.Web.Client.Services;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ItemsListResponseItem>> Get()
    {
        var items = await _httpClient.GetFromJsonAsync<List<ItemsListResponseItem>>("items.list");

        return items!;
    }
}