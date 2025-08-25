using System;
using System.Net.Http;
using WSDK.Resilience;

namespace WSDK.Configuration;

/// <summary>
/// Fluent builder for <see cref="WalacorClient"/> instances.
/// </summary>
public class WalacorClientBuilder
{
    private Uri? _baseAddress;
    private TimeSpan _timeout = TimeSpan.FromSeconds(100);
    private IRetryPolicy? _retryPolicy;

    public WalacorClientBuilder WithBaseAddress(Uri baseAddress)
    {
        _baseAddress = baseAddress;
        return this;
    }

    public WalacorClientBuilder WithTimeout(TimeSpan timeout)
    {
        _timeout = timeout;
        return this;
    }

    public WalacorClientBuilder WithRetryPolicy(IRetryPolicy retryPolicy)
    {
        _retryPolicy = retryPolicy;
        return this;
    }

    public WalacorClient Build()
    {
        var httpClient = new HttpClient
        {
            BaseAddress = _baseAddress ?? throw new InvalidOperationException("Base address must be provided."),
            Timeout = _timeout
        };

        var policy = _retryPolicy ?? new DefaultRetryPolicy();
        return new WalacorClient(httpClient, policy);
    }
}
