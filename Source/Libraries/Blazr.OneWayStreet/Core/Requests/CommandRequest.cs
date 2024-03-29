﻿/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================
namespace Blazr.OneWayStreet.Core;

public record struct CommandRequest<TRecord>(TRecord Item, CommandState State, CancellationToken Cancellation = new())
{
    public static CommandRequest<TRecord> Create(APICommandRequest<TRecord> command, CancellationToken cancellationToken)
    {
        return new()
        {
            Item = command.Item,
            State = command.State,
            Cancellation = cancellationToken
        };
    }
}

public enum CommandState
{
    None = 0,
    Add = 1,
    Update = 2,
    Delete = int.MaxValue
}
