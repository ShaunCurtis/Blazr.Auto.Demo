/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================
namespace Blazr.Flux;

public delegate FluxMutationResult<TRecord> FluxMutationDelegate<TIdentity, TRecord>(FluxContext<TIdentity, TRecord> item)
    where TRecord : class, IFluxRecord<TIdentity>, new();
