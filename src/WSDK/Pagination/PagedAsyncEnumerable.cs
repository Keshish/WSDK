using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace WSDK.Pagination;

/// <summary>
/// Helps iterate through paginated resources.
/// </summary>
public class PagedAsyncEnumerable<T> : IAsyncEnumerable<T>
{
    private readonly Func<string?, CancellationToken, Task<Page<T>>> _getPage;

    public PagedAsyncEnumerable(Func<string?, CancellationToken, Task<Page<T>>> getPage)
        => _getPage = getPage;

    public async IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        string? cursor = null;
        while (true)
        {
            var page = await _getPage(cursor, cancellationToken).ConfigureAwait(false);
            foreach (var item in page.Items)
                yield return item;

            if (page.NextCursor == null)
                yield break;

            cursor = page.NextCursor;
        }
    }

    public record Page<TItem>(IReadOnlyList<TItem> Items, string? NextCursor);
}
