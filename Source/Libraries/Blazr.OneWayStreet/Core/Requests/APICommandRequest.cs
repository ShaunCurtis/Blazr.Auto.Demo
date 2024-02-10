/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================
namespace Blazr.OneWayStreet.Core;

public record struct APICommandRequest<TRecord>(TRecord Item, CommandState State)
{
    public static APICommandRequest<TRecord> Create(CommandRequest<TRecord> command)
    {
        return new()
        {
            Item = command.Item,
            State = command.State,
        };
    }
}