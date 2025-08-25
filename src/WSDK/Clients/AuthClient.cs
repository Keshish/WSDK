using System;
using System.Threading;
using System.Threading.Tasks;
using WSDK.Errors;

namespace WSDK.Clients;

/// <summary>
/// Client for authentication operations.
/// </summary>
public class AuthClient
{
    private readonly WalacorClient _client;

    internal AuthClient(WalacorClient client) => _client = client;

    public Task<Result<string>> LoginAsync(string username, string password, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
