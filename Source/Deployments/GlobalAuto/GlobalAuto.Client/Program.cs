using Blazr.Infrastructure;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAppWebAssemblyInfrastructureServices(builder.HostEnvironment.BaseAddress);
builder.Services.AddAppWebAssemblyUIServices();

await builder.Build().RunAsync();
