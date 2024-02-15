/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================
namespace Blazr.App.Presentation;

public class WeatherForecastEditPresenter
{
    private ICommandHandler _commandHandler;
    private IItemRequestHandler _itemHandler;

    public WeatherForecastEditContext MutationContext { get; private set; } = new(new());
    public EditContext? EditContext { get; private set; }
    public IDataResult LastResult { get; private set; } = CommandResult.Success();

    public WeatherForecastEditPresenter(ICommandHandler commandHandler, IItemRequestHandler itemRequest)
    {
        _commandHandler = commandHandler;
        _itemHandler = itemRequest;
    }

    /// <summary>
    /// Loads the Edit Context with the weather forecast with the provided Uid 
    /// or a new weather forecast if the uid is null or no record exists
    /// </summary>
    /// <param name="uid"></param>
    /// <returns></returns>
    public async Task LoadAsync(Guid? uid)
    {
        WeatherForecast? item = null;

        if (uid is not null)
        {
            ItemQueryRequest query = new ItemQueryRequest() { KeyValue = uid };
            var result = await _itemHandler.ExecuteAsync<WeatherForecast>(query);
            this.LastResult = result;
            item = result.Item;
        }

        this.MutationContext = item is not null ? new(item) : WeatherForecastEditContext.AsNew();
        this.EditContext = new(this.MutationContext);
    }

    public async Task SaveAsync()
    {
        if (MutationContext is null)
        {
            this.LastResult = CommandResult.Failure("No Record Context to Save.");
            return;
        }

        var command = new CommandRequest<WeatherForecast>(MutationContext.AsRecord, MutationContext.GetCommandState());
        this.LastResult = await _commandHandler.ExecuteAsync(command);
    }

    public async Task DeleteAsync()
    {
        if (MutationContext is null)
        {
            this.LastResult = CommandResult.Failure("No Record Context to Delete.");
            return;
        }

        var command = new CommandRequest<WeatherForecast>(MutationContext.AsRecord, CommandState.Delete);
        this.LastResult = await _commandHandler.ExecuteAsync(command);
    }
}
