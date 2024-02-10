using Blazr.App.Core;
using Blazr.OneWayStreet.Core;
using Microsoft.AspNetCore.Mvc;

namespace Blazr.Configuration;

public static class InfrastructureServices
{
    public static void AddAppEndPoints(this WebApplication app)
    {
        app.MapPost(
            "/API/WeatherForecast/ListQuery",
            async (
                [FromBody] APIListQueryRequest listRequest,
                IListRequestHandler provider,
                CancellationToken cancelToken)
            =>
            {
                var request = new ListQueryRequest()
                {
                    StartIndex = listRequest.StartIndex,
                    PageSize = listRequest.PageSize,
                    Filters = listRequest.Filters,
                    Sorters = listRequest.Sorters,
                    Cancellation = cancelToken
                };

                var result = await provider.ExecuteAsync<WeatherForecast>(request);
                return result;
            });
    }
}
