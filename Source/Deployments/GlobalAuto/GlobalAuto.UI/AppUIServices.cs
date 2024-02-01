using Blazr.UI.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Blazr.Infrastructure;

public static class AppUIServices
{
    public static void AddAppServerUIServices(this IServiceCollection services)
    {
        services.AddScoped<IRenderModeProvider, ServerRenderModeProvider>();
    }

    public static void AddAppWebAssemblyUIServices(this IServiceCollection services)
    {
        services.AddScoped<IRenderModeProvider, WebAssemblyRenderModeProvider>();
    }
}
