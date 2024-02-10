/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================
namespace Blazr.OneWayStreet.Core;

/// <summary>
/// This object is used to return the list results from a ListQuery
/// It's designed to work with paging.  It provides the page and a total count
/// It also provides status information and in the case of failure a message 
/// </summary>
/// <typeparam name="TRecord">The record type of Items</typeparam>
public sealed record ListQueryResult<TRecord> : IDataResult
{
    public IEnumerable<TRecord> Items { get; init;} = Enumerable.Empty<TRecord>();  
    public bool Successful { get; init; }
    public string? Message { get; init; }
    public long TotalCount { get; init; }

    public ListQueryResult() { }

    public static ListQueryResult<TRecord> Success(IEnumerable<TRecord> Items, long totalCount, string? message = null)
        => new ListQueryResult<TRecord> {Successful=true,  Items= Items, TotalCount = totalCount, Message= message };

    public static ListQueryResult<TRecord> Failure(string message)
        => new ListQueryResult<TRecord> { Message = message};
}
