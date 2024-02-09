using Blazr.RenderState.WASM;
using Blazr.App.Infrastructure;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAppClientInfrastructureServices(builder.HostEnvironment.BaseAddress);
builder.AddBlazrRenderStateWASMServices();

await builder.Build().RunAsync();
