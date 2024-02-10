/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================
namespace Blazr.OneWayStreet.Core;

public readonly record struct ItemQueryRequest
{
    public object KeyValue { get; init; }
    public CancellationToken Cancellation { get; init; }

    public ItemQueryRequest(object keyValue, CancellationToken? cancellation = null)
    {
        this.KeyValue = keyValue;
        this.Cancellation = cancellation ?? new(); ;
    }
}
