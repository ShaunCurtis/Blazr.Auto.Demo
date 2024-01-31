namespace Blazr.Core;

public readonly record struct ListRequest(int StartIndex, int PageSize)
{
    public static ListRequest Default()
        => new(0, 1000);
} 

