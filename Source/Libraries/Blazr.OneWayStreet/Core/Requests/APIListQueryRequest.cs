/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================
namespace Blazr.OneWayStreet.Core;

/// <summary>
/// An object to pass a list query request over an API call
/// </summary>
public sealed record APIListQueryRequest
{
    public int StartIndex { get; init; } = 0;
    public int PageSize { get; init; } = 1000;
    public List<FilterDefinition> Filters { get; init; } = new();
    public List<SortDefinition> Sorters { get; init; } = new();

    public static APIListQueryRequest Create(ListQueryRequest request)
    {
        return new APIListQueryRequest()
        {
            StartIndex = request.StartIndex,
            PageSize = request.PageSize,
            Filters = request.Filters,
            Sorters = request.Sorters,
        };
    }
}


