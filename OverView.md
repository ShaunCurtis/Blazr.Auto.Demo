# OverView

Newcomers to Single Page Applications often struggle with the paradigm shift.  It's very hard to conceptualise an interactive page.  How to you save data in a form without submitting the form to the server.

I'll start with a Blazor Web Assembly application.

Somewhere you have some sort of file server: a web server or a file system.  The web server may server a static file or build it server side.  

It doesn't matter: the web browser downloads a text file with a `<!DOCTYPE html>` content type and renders it.  As part of that render process you download and run:

```csharp
    <script src="_framework/blazor.web.js"></script>
```

This pulls down the necessary JS files and WASM Dll's from the file source.  It sets up the Blazor Web Assembly container and JS services to interact with browser session. 

Once the Blazor WASM container and JS services are up and running, the Renderer creates the interactivity render tree roots, drives a render tree cascade and pushes those changes through the diffing engine into the browser.

At this point the page in interactive.  The final *event* of the initial render process is the `AfterRender` event from the browser into the Blazor WASM environment.  This triggers all the component registered `OnAfterRender{Async}`.  

Activity is now driven by background services running in the Blazor Web Assembly Container and UI and Browser events. 