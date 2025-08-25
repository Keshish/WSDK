using System;
using System.Threading;
using System.Threading.Tasks;
using WSDK.Errors;

namespace WSDK.Operations;

/// <summary>
/// Represents a long running operation that can be polled for completion.
/// </summary>
public class LongRunningOperation<T>
{
    private readonly Func<string, CancellationToken, Task<Result<T>>> _poll;

    public string OperationId { get; }

    public LongRunningOperation(string operationId, Func<string, CancellationToken, Task<Result<T>>> poll)
    {
        OperationId = operationId;
        _poll = poll;
    }

    public Task<Result<T>> WaitForCompletionAsync(CancellationToken cancellationToken = default)
        => _poll(OperationId, cancellationToken);
}
