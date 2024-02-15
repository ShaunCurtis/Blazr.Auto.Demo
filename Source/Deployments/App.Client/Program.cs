using Blazr.RenderState.WASM;
using Blazr.App.Infrastructure;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazr.App.Presentation;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAppClientInfrastructureServices(builder.HostEnvironment.BaseAddress);
builder.Services.AddAppPresentationServices();

builder.AddBlazrRenderStateWASMServices();

await builder.Build().RunAsync();
