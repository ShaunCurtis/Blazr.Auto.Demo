using Microsoft.AspNetCore.Http;

namespace Blazr.UI;
public interface IRenderModeProvider
{
    public ComponentRenderMode RenderMode { get; }
}


public class ServerRenderModeProvider : IRenderModeProvider
{
    IHttpContextAccessor _httpContextAccessor;
    public ComponentRenderMode RenderMode =>
        !(_httpContextAccessor.HttpContext is not null && _httpContextAccessor.HttpContext.Response.HasStarted)
            ? ComponentRenderMode.PreRender
            : ComponentRenderMode.Server;


    public ServerRenderModeProvider(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
}

public class WebAssemblyRenderModeProvider : IRenderModeProvider
{
    public ComponentRenderMode RenderMode => ComponentRenderMode.WebAssembly;
}

public enum ComponentRenderMode
{
    PreRender,
    Server,
    WebAssembly
}
