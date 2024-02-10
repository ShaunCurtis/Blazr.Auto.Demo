/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================
namespace Blazr.Flux;

public class FluxContext<TIdentity,TRecord>
    where TRecord : class, IFluxRecord<TIdentity>, new()
{
    private TRecord _immutableItem;

    public TIdentity Id => _immutableItem.Id;
    public TRecord ImmutableItem => _immutableItem;

    public FluxState State { get; private set; }

    /// <summary>
    /// Event raised when a context mutates
    /// </summary>
    public event EventHandler<FluxState>? StateHasChanged;

    public FluxContext(TRecord item, FluxState? state = null)
    {
        _immutableItem = item;
        this.State = state ?? FluxState.New();
    }

    public FluxResult Dispatch(FluxMutationDelegate<TIdentity, TRecord> mutation)
    {
        var mutationResult = mutation.Invoke(this);
        if (mutationResult.Item == _immutableItem)
            return FluxResult.Failure("No changes to apply.");

        _immutableItem = mutationResult.Item;
        if (!this.State.IsNew)
            this.State = this.State.Mutate();

        this.NotifyStateHasChanged();
        return FluxResult.Success();
    }

    public void MarkAsPersisted()
    {
        this.State = FluxState.Existing();
        this.NotifyStateHasChanged();
    }

    public void MarkForDeletion()
    {
        this.State = this.State.Delete();
        this.NotifyStateHasChanged();
    }

    public void NotifyStateHasChanged()
    {
        this.StateHasChanged?.Invoke(_immutableItem, State);
    }
}