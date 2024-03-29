using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BGU.MarvelChampions.Services;

// https://docs.microsoft.com/fr-fr/dotnet/architecture/cloud-native/service-to-service-communication
// https://docs.microsoft.com/fr-fr/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client
public abstract class ApiGatewayService
{
    private readonly IConfiguration _configuration;
    private readonly IHttpClientFactory _httpClientFactory;

    private Uri ApiGatewayUri
    {
        get { return new Uri(_configuration["ApiGatewayUrl"]); }
    }

    public ApiGatewayService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
    {
        _configuration = configuration;
        _httpClientFactory = httpClientFactory;
    }

    protected async Task<T?> RequestGetAsync<T>(string? relativeUri)
    {
        var httpClient = _httpClientFactory.CreateClient();
        var uri = new Uri(ApiGatewayUri, relativeUri);
        var response = await httpClient.GetAsync(uri);
        if (!response.IsSuccessStatusCode)
        {
            return default(T);
        }

        return await JsonSerializer.DeserializeAsync<T>(await response.Content.ReadAsStreamAsync());
    }

    protected async Task<TResponse?> RequestPostAsync<TRequest, TResponse>(string? relativeUri, TRequest data)
    {
        var httpClient = _httpClientFactory.CreateClient();
        var uri = new Uri(ApiGatewayUri, relativeUri);
        string jsonData = JsonSerializer.Serialize(data);
        using (var content = new StringContent(jsonData, Encoding.UTF8, "application/json"))
        {
            var response = await httpClient.PostAsync(uri, content);
            if (!response.IsSuccessStatusCode)
            {
                return default(TResponse);
            }

            return await JsonSerializer.DeserializeAsync<TResponse>(await response.Content.ReadAsStreamAsync());
        }
    }
}
