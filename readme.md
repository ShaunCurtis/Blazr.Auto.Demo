DoteNetCore 8 introduced a set of new features in Blazor to integrate Server Side Rendering and Blazor's Server and Web Assembly rendering modes.

This repository demonstrates the new features and provides some patterns for deployments.

## Design Framework

The solution applies *Clean Design* principles.  Code is split into a number of projects to represent the design domains with strict  Clean Design Dependencies applied.

## Forms and Pages

In the solution I've divided the traditional *Page* into two components.  The *Form* contains everything but the `@Page` and `@RenderMode` directives.

The page now looks like this:

```csharp
@page "/weather"
<PageTitle>Weather</PageTitle>
@rendermode InteractiveWebAssembly

<WeatherForecastListForm />
```

This separates out the implementation from the layout of the site.  A form can be reused in different pages or Deployments.

In th solution the same form is used in various deployments.


