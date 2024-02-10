/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================
using Blazr.OneWayStreet.Core;

namespace Blazr.Flux;

public record FluxResult : IDataResult
{
    public bool Successful { get; init; }
    public string? Message { get; init; }

    public static FluxResult Success()
        => new FluxResult() { Successful = true };

    public static FluxResult Failure(string message)
        => new FluxResult() { Successful = false, Message = message };
}