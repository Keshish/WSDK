using System;
using System.Threading;
using System.Threading.Tasks;

namespace WSDK.Resilience;

/// <summary>
/// A naive retry policy placeholder. Real implementation should use exponential backoff with jitter
/// and respect idempotency and Retry-After headers.
/// </summary>
public class DefaultRetryPolicy : IRetryPolicy
{
    public async Task<T> ExecuteAsync<T>(Func<CancellationToken, Task<T>> action, CancellationToken cancellationToken)
    {
        // Simplistic single attempt implementation.
        return await action(cancellationToken).ConfigureAwait(false);
    }
}
