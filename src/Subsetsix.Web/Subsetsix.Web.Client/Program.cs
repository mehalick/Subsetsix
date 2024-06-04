using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Subsetsix.Web.Client.Services;

namespace Subsetsix.Web.Client;

internal class Program
{
    static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);

        await builder.Build().RunAsync();
    }
}
