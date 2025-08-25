using System;
using System.Threading;
using System.Threading.Tasks;

namespace WSDK.Resilience;

/// <summary>
/// Defines an abstraction for retrying transient failures.
/// </summary>
public interface IRetryPolicy
{
    Task<T> ExecuteAsync<T>(Func<CancellationToken, Task<T>> action, CancellationToken cancellationToken);
}
