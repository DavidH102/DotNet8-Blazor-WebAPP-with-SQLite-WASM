
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using SqliteWasmHelper;

namespace WebAPP_with_SQLite_WASM.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddSqliteWasmDbContextFactory<ThingContext>(opts =>
            {
                opts.UseSqlite("Data Source=things.sqlite3");
                opts.LogTo(_ => { }, LogLevel.None);  // Disable EF Core logging for performance reasons
            });
            await builder.Build().RunAsync();
        }
    }
}
