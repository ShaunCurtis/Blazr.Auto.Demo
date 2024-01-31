namespace Blazr.Core;

public readonly record struct ListResult<TRecord>(
    bool Successful, 
    IEnumerable<TRecord> Items, 
    int TotalCount, 
    string? Message = null)
    : IDataResult
{
    public static ListResult<TRecord> Success(IEnumerable<TRecord> items, int totalCount)
        => new ListResult<TRecord>(true, items, totalCount);

    public static ListResult<TRecord> Failure(string? message)
        => new ListResult<TRecord>(false, Enumerable.Empty<TRecord>(), 0, message );
}
