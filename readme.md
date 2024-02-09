
> Under Construction

DoteNetCore 8 introduced a set of new features in Blazor to integrate Server Side Rendering and Blazor's Server and Web Assembly rendering modes.

This repository demonstrates the new features and provides some patterns for deployments.

## Design Framework

The solution applies *Clean Design* principles.  Code is split into a number of projects to represent the design domains with strict  Clean Design Dependencies applied.

### Clean Design in a Nutshell

If you are unfamiliar with *Clean Design*, it sets out to separate the business objects and logic - the essence of the application that differentiates it from every other application - from the infrastructure it depends on and the processes that use and interact with it.

In my solutions this breaks down into *Core*, *Infrastructure* and *Presentation*.  UI's and API's hang off *Presentation*.  Databases and API's are accessed through *Infrastructure*.
 
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

In the solution the same form is used in various deployments.

> In Progress


