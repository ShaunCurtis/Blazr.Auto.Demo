/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================
namespace Blazr.Configuration;

public static class InfrastructureServices
{
    public static void AddAppEndPoints(this WebApplication app)
    {
        app.AddRecordEndPoints<WeatherForecast>();
    }

    public static void AddRecordEndPoints<TRecord>(this WebApplication app)
        where TRecord : class
    {
        var recName = typeof(TRecord).Name;

        app.MapPost(
            $"/API/{recName}/ListQuery",
            async (
                [FromBody] APIListQueryRequest listRequest,
                IListRequestHandler provider,
                CancellationToken cancelToken)
            =>
            {
                var request = ListQueryRequest.Create(listRequest);
                var result = await provider.ExecuteAsync<TRecord>(request);
                return result;
            });

        app.MapPost(
            $"/API/{recName}/ItemQuery",
            async (
                [FromBody] APIItemQueryRequest itemRequest,
                IItemRequestHandler provider,
                IItemRequestConverter itemRequestConverter,
                CancellationToken cancelToken)
            =>
            {
                var request = itemRequestConverter.Convert(itemRequest, cancelToken);
                var result = await provider.ExecuteAsync<TRecord>(request);
                return result;
            });

        app.MapPost(
            $"/API/{recName}/Command",
            async (
                [FromBody] APICommandRequest<TRecord> command,
                ICommandHandler provider,
                CancellationToken cancelToken)
            =>
            {
                var request = CommandRequest<TRecord>.Create(command, cancelToken);
                var result = await provider.ExecuteAsync<TRecord>(request);
                return result;
            });
    }
}
