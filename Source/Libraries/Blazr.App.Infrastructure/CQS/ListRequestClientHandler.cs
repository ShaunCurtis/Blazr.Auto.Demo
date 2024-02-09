/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================

namespace Blazr.App.Infrastructure;

public sealed class ListRequestClientHandler
    : IListRequestHandler
{
    private readonly IServiceProvider _serviceProvider;
    private IHttpClientFactory _httpClientFactory;

    public ListRequestClientHandler(IHttpClientFactory httpClientFactory, IServiceProvider serviceProvider)
    {
        _httpClientFactory = httpClientFactory;
        _serviceProvider = serviceProvider;
    }

    public async ValueTask<ListQueryResult<TRecord>> ExecuteAsync<TRecord>(ListQueryRequest request)
        where TRecord : class
    {
        // Try and get a registered custom handler
        var _customHandler = _serviceProvider.GetService<IListRequestHandler<TRecord>>();

        // If we one is registered in DI and execute it
        if (_customHandler is not null)
            return await _customHandler.ExecuteAsync(request);

        // If not run the base handler
        return await this.GetItemsAsync<TRecord>(request);
    }

    private async ValueTask<ListQueryResult<TRecord>> GetItemsAsync<TRecord>(ListQueryRequest request)
    where TRecord : class
    {
        using var httpClient = _httpClientFactory.CreateClient("ServerAPI");

        var APIRequest = new APIListQueryRequest() { StartIndex = request.StartIndex, PageSize = request.PageSize, Sorters = request.Sorters, Filters = request.Filters };
        var recName = typeof(TRecord).Name;
        var httpResult = await httpClient.PostAsJsonAsync<APIListQueryRequest>($"/API/{recName}/ListQuery", APIRequest, request.Cancellation);

        if (httpResult.IsSuccessStatusCode)
        {
            var listResult = await httpResult.Content.ReadFromJsonAsync<ListQueryResult<TRecord>>();
            if (listResult is not null)
                return listResult;
        }
        return ListQueryResult<TRecord>.Failure($"Request failed.  Error Code: {httpResult.StatusCode.ToString()}");
    }
}