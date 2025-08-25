using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using WSDK.Errors;

namespace WSDK.Streaming;

/// <summary>
/// Supports streaming file uploads with progress reporting.
/// </summary>
public class FileUploader
{
    private readonly WalacorClient _client;

    internal FileUploader(WalacorClient client) => _client = client;

    public Task<Result<string>> UploadAsync(
        Stream content,
        IProgress<long>? progress = null,
        CancellationToken cancellationToken = default) =>
        throw new NotImplementedException();
}
