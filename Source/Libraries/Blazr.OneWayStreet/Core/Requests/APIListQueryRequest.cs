/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================
namespace Blazr.OneWayStreet.Core;

public sealed record APIListQueryRequest
{
    public int StartIndex { get; init; } = 0;
    public int PageSize { get; init; } = 1000;
    public List<FilterDefinition> Filters { get; init; } = new();
    public List<SortDefinition> Sorters { get; init; } = new();
}
