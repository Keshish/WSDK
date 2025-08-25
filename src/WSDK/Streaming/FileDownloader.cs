using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using WSDK.Errors;

namespace WSDK.Streaming;

/// <summary>
/// Supports streaming file downloads with basic integrity validation.
/// </summary>
public class FileDownloader
{
    private readonly WalacorClient _client;

    internal FileDownloader(WalacorClient client) => _client = client;

    public Task<Result<Stream>> DownloadAsync(string path, CancellationToken cancellationToken = default)
        => throw new NotImplementedException();
}
