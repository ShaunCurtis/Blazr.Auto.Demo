using Blazr.Configuration;
using Blazr.App.Infrastructure.Server;
using App.UI;
using Microsoft.EntityFrameworkCore;
using Blazr.RenderState.Server;
using Blazr.App.Presentation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// Adds the application Services
builder.Services.AddAppServerInfrastructureServices();
builder.Services.AddAppPresentationServices();
builder.AddBlazrRenderStateServerServices();

var app = builder.Build();

// get the DbContext factory and add the test data
var factory = app.Services.GetService<IDbContextFactory<InMemoryTestDbContext>>();
if (factory is not null)
    TestDataProvider.Instance().LoadDbContext<InMemoryTestDbContext>(factory);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

// Adds the application endpoints
app.AddAppEndPoints();

app.MapRazorComponents<App.UI.Components.App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(App.Server.Components.Error).Assembly);

app.Run();
