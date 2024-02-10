/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================
using System.Collections.ObjectModel;

namespace Blazr.Flux;

public class FluxContextProvider<TIdentity, TRecord>
    where TIdentity : struct
{
    private Dictionary<TIdentity, TRecord> _contexts { get; set; } = new Dictionary<TIdentity, TRecord>();

    public ReadOnlyDictionary<TIdentity, TRecord> Contexts => _contexts.AsReadOnly();

    public TRecord? GetEntity(TIdentity uid)
    {
        if (!_contexts.ContainsKey(uid))
            return default(TRecord);

        return this._contexts[uid];
    }

    public bool AddEntity(TIdentity id, TRecord item)
    {
        return _contexts.TryAdd(id, item);
    }

    public bool ClearEntity(TIdentity id)
    {
        return _contexts.Remove(id);
    }
}
