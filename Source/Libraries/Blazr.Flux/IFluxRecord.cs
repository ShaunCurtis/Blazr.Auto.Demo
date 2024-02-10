/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================
namespace Blazr.Flux;

public interface IFluxRecord<TIdentity>
{
    TIdentity Id { get; }
}

