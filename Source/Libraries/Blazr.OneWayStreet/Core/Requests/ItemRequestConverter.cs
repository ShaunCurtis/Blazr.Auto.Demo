/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================

namespace Blazr.OneWayStreet.Core;

public interface IItemRequestConverter
{
    public ItemQueryRequest Convert(APIItemQueryRequest request, CancellationToken? cancellationToken);
}
public class ItemRequestConverter : IItemRequestConverter
{
    public ItemQueryRequest Convert(APIItemQueryRequest request, CancellationToken? cancellationToken = null)
    {
        if (int.TryParse(request.KeyValue, out int intValue))
            return new ItemQueryRequest(intValue, cancellationToken ?? new());

        if (Guid.TryParse(request.KeyValue, out Guid guidValue))
            return new ItemQueryRequest(guidValue, cancellationToken ?? new());

        return new ItemQueryRequest(request.KeyValue, cancellationToken ?? new());

    }
}
