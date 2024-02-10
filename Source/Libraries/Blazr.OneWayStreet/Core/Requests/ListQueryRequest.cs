/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================
namespace Blazr.OneWayStreet.Core;

/// <summary>
/// An object used to request a list of records
/// It's paged by default to 1000 items.
/// The filters and sorters are name based objects
/// to make it compatible with API calls.
/// </summary>
public sealed record ListQueryRequest
{
    public int StartIndex { get; init; } = 0;
    public int PageSize { get; init; } = 1000;
    public CancellationToken Cancellation { get; set; } = new();
    public List<FilterDefinition> Filters { get; init; } = new();
    public List<SortDefinition> Sorters { get; init; } = new();

    public static ListQueryRequest Create(APIListQueryRequest request, CancellationToken? cancellationToken = null)
    {
        return new()
        {
            StartIndex = request.StartIndex,
            PageSize = request.PageSize,
            Filters = request.Filters,
            Sorters = request.Sorters,
            Cancellation = cancellationToken ?? new()
        };
    }
}
