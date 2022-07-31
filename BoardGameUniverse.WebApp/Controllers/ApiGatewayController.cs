using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace BoardGameUniverse.WebApp.Controllers;

public class ApiGatewayController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ApiGatewayController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<HttpResponseMessage> SendHttpRequestAsync(string method, string requestUri)
    {
        var message = new HttpRequestMessage(new HttpMethod(method), requestUri);
        if (Request.ContentLength > 0)
        {
            message.Content = new StreamContent(Request.Body);
            message.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
        }

        var response = await SendHttpRequestAsync(message);
        if (!response.IsSuccessStatusCode)
        {
            string responseBody = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"TransferRequest failed. requestUri: {requestUri}, Returned HTTP status: {response.StatusCode}, Returned body: {responseBody}");
        }

        return response;
    }

    public async Task<T> SendHttpGetRequestAsync<T>(string requestUri)
    {
        var response = await SendHttpRequestAsync("GET", requestUri);
        return await JsonSerializer.DeserializeAsync<T>(await response.Content.ReadAsStreamAsync());
    }

    private async Task<HttpResponseMessage> SendHttpRequestAsync(HttpRequestMessage requestMessage)
    {
        var cts = new CancellationTokenSource();
        try
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.SendAsync(requestMessage);
            response.EnsureSuccessStatusCode();
            return response;
        }
        catch (Exception ex)
        {
            string message = $"An error occured while requesting JSON asynchronous response [Uri: '{requestMessage.RequestUri}', Action: '{requestMessage.Method}'].";
            if (ex.InnerException is TaskCanceledException tex && tex.CancellationToken != cts.Token)
            {
                throw new TimeoutException(message, ex);
            }

            throw new InvalidOperationException(message, ex);
        }
    }
}
