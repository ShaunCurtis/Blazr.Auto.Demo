
using Blazr.OneWayStreet.Core.Requests;

/// ============================================================
/// Author: Shaun Curtis, Cold Elm Coders
/// License: Use And Donate
/// If you use it, donate something to a charity somewhere
/// ============================================================
namespace Blazr.App.Infrastructure;

public static class ApplicationClientInfrastructureServices
{
    public static void AddAppClientInfrastructureServices(this IServiceCollection services, string baseUrl)
    {

        services.AddHttpClient("ServerAPI", client => client.BaseAddress = new Uri(baseUrl));

        // Add the standard handlers
        services.AddScoped<IListRequestHandler, ListRequestClientHandler>();
        services.AddSingleton<IItemRequestConverter, ItemRequestConverter>();
        //services.AddScoped<IItemRequestHandler, ItemRequestServerHandler<InMemoryTestDbContext>>();
        //services.AddScoped<ICommandHandler, CommandServerHandler<InMemoryTestDbContext>>();

        // Add any individual entity services
    }


    //public static void AddAppServerMappedInfrastructureServices(this IServiceCollection services)
    //{
    //    services.AddDbContextFactory<InMemoryTestDbContext>(options
    //        => options.UseInMemoryDatabase($"TestDatabase-{Guid.NewGuid().ToString()}"));

    //    services.AddScoped<IDataBroker, ServerDataBroker>();

    //    // Add the standard handlers
    //    services.AddScoped<IListRequestHandler, ListRequestServerHandler<InMemoryTestDbContext>>();
    //    services.AddScoped<IItemRequestHandler, ItemRequestServerHandler<InMemoryTestDbContext>>();
    //    services.AddScoped<ICommandHandler, CommandServerHandler<InMemoryTestDbContext>>();

    //    // Add any individual entity services
    //    services.AddMappedWeatherForecastServerInfrastructureServices();
    //}
}
