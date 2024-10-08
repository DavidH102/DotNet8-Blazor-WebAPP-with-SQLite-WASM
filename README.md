# SqliteWasmHelper Demo for .NET 8 WebApp

This project uses the [SqliteWasmHelper](https://github.com/JeremyLikness/SqliteWasmHelper) repository to demonstrate working with SQLite in a Blazor WebAssembly app using the new .NET 8 WebApp template. The project has been updated to work with both WebAssembly and server-side Blazor.

> **Note**: This demo follows the original SqliteWasmHelper repository with modifications for the .NET 8 WebApp template. You can follow the [original project here](https://github.com/JeremyLikness/SqliteWasmHelper) for further reference.

## Overview

This demo shows how to integrate SQLite in a .NET 8 WebApp template app, leveraging the new .NET 8 WebApp template that supports hybrid rendering modes. The project allows for running in both WebAssembly and server-side modes while keeping data persistence in the browser using SQLite.

## Demo Link

Check out the live demo: [dotnet8-blazor-webapp-with-sqlite-wasm.azurewebsites.net](https://dotnet8-blazor-webapp-with-sqlite-wasm.azurewebsites.net)


## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- WebAssembly Tools for .NET 8

## Setup Instructions

To replicate this demo in your own environment, follow these steps:

1. **Install the SqliteWasmHelper NuGet Package**:
   Install the package using:
   ```bash
   dotnet add package SqliteWasmHelper
   ```

2. **Project Configuration**:
   Add this snippet to your `.csproj` to enable WebAssembly native support:
   ```xml
   <PropertyGroup>
       <WasmBuildNative>true</WasmBuildNative>
   </PropertyGroup>
   ```

3. **Update `Program.cs`**:
   Register the SQLite DbContext factory for your Blazor WebApp:
   ```csharp
   using SqliteWasmHelper;
   
   builder.Services.AddSqliteWasmDbContextFactory<YourDbContext>(
       options => options.UseSqlite("Data Source=yourdatabase.db"));
   ```

4. **Use in Blazor Components**:
   Inject the factory into your components:
   ```csharp
   @inject ISqliteWasmDbContextFactory<YourDbContext> Factory

   var dbContext = await Factory.CreateDbContextAsync();
   dbContext.Entities.Add(new Entity { Name = "Sample" });
   await dbContext.SaveChangesAsync();
   ```

## Running the Demo

You can run this demo in two ways:
- **Blazor WebAssembly**: Runs purely client-side with SQLite cached in the browser.
- **Server-Side Blazor**: Data persistence and synchronization with a backend can be added.

To run the project, simply execute:
```bash
dotnet run
```

## Important Notes

- **Data Persistence**: The SQLite database is stored in browser cache. Always use `SaveChangesAsync` to persist data properly.
- **Server-Side Consideration**: While this demo supports WebAssembly caching, you can easily add backend data synchronization for server-side Blazor scenarios.

## Original Repository

For more advanced usage, documentation, and features, please visit the [original SqliteWasmHelper repository](https://github.com/JeremyLikness/SqliteWasmHelper).

## License

This project uses the same MIT License as the original SqliteWasmHelper repository. See the [LICENSE](./LICENSE.txt) file for more details.
