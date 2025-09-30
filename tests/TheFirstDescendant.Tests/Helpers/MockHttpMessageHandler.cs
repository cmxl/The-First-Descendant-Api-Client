using System.Net;
using System.Text;

namespace TheFirstDescendant.Tests.Helpers;

public class MockHttpMessageHandler : HttpMessageHandler
{
    private readonly Dictionary<string, MockHttpResponse> _responses = new();
    private readonly List<HttpRequestMessage> _requests = new();

    public IReadOnlyList<HttpRequestMessage> Requests => _requests.AsReadOnly();

    public void AddResponse(string url, HttpStatusCode statusCode, string content = "", string contentType = "application/json")
    {
        _responses[url] = new MockHttpResponse
        {
            StatusCode = statusCode,
            Content = content,
            ContentType = contentType
        };
    }

    public void AddSuccessResponse<T>(string url, T responseObject)
    {
        var json = System.Text.Json.JsonSerializer.Serialize(responseObject);
        AddResponse(url, HttpStatusCode.OK, json);
    }

    public void AddErrorResponse(string url, HttpStatusCode statusCode, string errorMessage = "")
    {
        var errorContent = string.IsNullOrEmpty(errorMessage)
            ? $"{{\"error_code\": \"{(int)statusCode}\", \"error_message\": \"{statusCode}\"}}"
            : errorMessage;
        AddResponse(url, statusCode, errorContent);
    }

    public void Clear()
    {
        _responses.Clear();
        _requests.Clear();
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        _requests.Add(request);

        var url = request.RequestUri?.ToString() ?? "";

        if (_responses.TryGetValue(url, out var mockResponse))
        {
            var response = new HttpResponseMessage(mockResponse.StatusCode);
            if (!string.IsNullOrEmpty(mockResponse.Content))
            {
                response.Content = new StringContent(mockResponse.Content, Encoding.UTF8, mockResponse.ContentType);
            }
            return Task.FromResult(response);
        }

        // Default to NotFound if no mock response is configured
        return Task.FromResult(new HttpResponseMessage(HttpStatusCode.NotFound));
    }

    private class MockHttpResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Content { get; set; } = "";
        public string ContentType { get; set; } = "application/json";
    }
}