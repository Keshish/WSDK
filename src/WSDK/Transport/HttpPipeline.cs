using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WSDK.Resilience;

namespace WSDK.Transport;

/// <summary>
/// Wraps HTTP transport concerns such as retries and error handling.
/// </summary>
public class HttpPipeline
{
    private readonly HttpClient _httpClient;
    private readonly IRetryPolicy _retryPolicy;

    public HttpPipeline(HttpClient httpClient, IRetryPolicy retryPolicy)
    {
        _httpClient = httpClient;
        _retryPolicy = retryPolicy;
    }

    public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        => _retryPolicy.ExecuteAsync(ct => _httpClient.SendAsync(request, ct), cancellationToken);
}
