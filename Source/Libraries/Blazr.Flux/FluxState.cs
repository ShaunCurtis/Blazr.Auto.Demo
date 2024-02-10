/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================
namespace Blazr.Flux;

public readonly record struct FluxState
{
    public bool IsNew { get; private init; }
    public bool IsMutated { get; private init; }
    public bool IsDeleted { get; private init; }

    /// <summary>
    /// Creates a new Flux State from the exisitng state with the IsMutated flag set
    /// </summary>
    /// <returns></returns>
    public FluxState Mutate()
        => this with { IsMutated = true };

    /// <summary>
    /// Creates a new Flux State from the exisitng state with the IsDeleted flag set
    /// </summary>
    /// <returns></returns>
    public FluxState Delete()
        => this with { IsDeleted = true };

    /// <summary>
    /// Creates a new Flux State with the IsMutated flag set
    /// </summary>
    /// <returns></returns>
    public static FluxState New()
        => new() { IsNew = true };

    /// <summary>
    /// Creates a new Flux State with no flags set
    /// </summary>
    /// <returns></returns>
    public static FluxState Existing()
        => new();
}

