using System;
using System.Threading;
using System.Threading.Tasks;
using WSDK.Errors;

namespace WSDK.Clients;

/// <summary>
/// Client for schema operations.
/// </summary>
public class SchemaClient
{
    private readonly WalacorClient _client;

    internal SchemaClient(WalacorClient client) => _client = client;

    public Task<Result<string>> GetSchemaAsync(string id, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
