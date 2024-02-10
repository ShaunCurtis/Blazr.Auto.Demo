/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================
namespace Blazr.OneWayStreet.Core;

public readonly record struct APIItemQueryRequest
{
    public string KeyValue  { get; init; }

    public static APIItemQueryRequest Create(ItemQueryRequest request)
    {
        return new APIItemQueryRequest()
        {
            KeyValue = request.KeyValue?.ToString() ?? string.Empty
        };
    }
}
