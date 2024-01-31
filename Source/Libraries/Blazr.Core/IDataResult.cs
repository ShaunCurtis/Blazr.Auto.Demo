namespace Blazr.Core;

public interface IDataResult
{
    public bool Successful { get; }
    public string? Message { get; }
}
