using System.Net.Http;
using WSDK.Clients;
using WSDK.Resilience;

namespace WSDK;

/// <summary>
/// Entry point for accessing Walacor services.
/// </summary>
public class WalacorClient
{
    internal HttpClient HttpClient { get; }
    internal IRetryPolicy RetryPolicy { get; }

    public AuthClient Auth { get; }
    public SchemaClient Schema { get; }

    internal WalacorClient(HttpClient httpClient, IRetryPolicy retryPolicy)
    {
        HttpClient = httpClient;
        RetryPolicy = retryPolicy;
        Auth = new AuthClient(this);
        Schema = new SchemaClient(this);
    }
}
