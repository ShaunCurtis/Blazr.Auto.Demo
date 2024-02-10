/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================
using Blazr.OneWayStreet.Core;

namespace Blazr.Flux;

public record FluxMutationResult<T>
        where T : class
{
    public T Item { get; init; } = default!;
    public bool Successful { get; init; }
    public string? Message { get; init; }

    public FluxResult FluxResult => new() { Successful= this.Successful,  Message = this.Message };
    
    public static FluxMutationResult<T> Success(T item, string? message = null)
        => new FluxMutationResult<T>() { Successful = true, Item = item, Message = message };

    public static FluxMutationResult<T> Failure(string message, T? item = null)
        => new FluxMutationResult<T>() { Successful = false, Message = message, Item = item! };
}
