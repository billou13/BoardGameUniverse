using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace BoardGameUniverse.WebApp.Controllers;

public class ApiGatewayController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ApiGatewayController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<HttpResponseMessage> TransferRequest(string url)
    {
        var message = new HttpRequestMessage(new HttpMethod(Request.Method), url);
        if (Request.ContentLength > 0)
        {
            message.Content = new StreamContent(Request.Body);
            message.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
        }

        var response = await SendHttpRequestAsync(message, ensureSuccessStatusCode: false);
        if (!response.IsSuccessStatusCode)
        {
            string responseBody = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"TransferRequest failed. URL: {url}, Returned HTTP status: {response.StatusCode}, Returned body: {responseBody}");
        }

        return response;
    }

    private async Task<HttpResponseMessage> SendHttpRequestAsync(HttpRequestMessage requestMessage, bool ensureSuccessStatusCode)
    {
        var cts = new CancellationTokenSource();

        try
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.SendAsync(requestMessage);
            if(ensureSuccessStatusCode)
            {
                response.EnsureSuccessStatusCode();
            }

            return response;
        }
        catch (Exception ex)
        {
            string message = $"An error occured while requesting JSON asynchronous response [Uri: '{requestMessage.RequestUri}', Action: GET].";
            if (ex.InnerException is TaskCanceledException tex && tex.CancellationToken != cts.Token)
            {
                throw new TimeoutException(message, ex);
            }

            throw new InvalidOperationException(message, ex);
        }
    }
}
