using MachineCommandCenter.Client.Services;
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;

namespace MachineCommandCenter.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            //builder.Services
            //  .AddBlazorise(options =>
            //  {
            //      options.ChangeTextOnKeyPress = true;
            //  })
            //  .AddBootstrapProviders()
            //  .AddFontAwesomeIcons();
            
            //builder.Services.AddHttpClient<IMachineDataService, MachineDataService>(client => client.BaseAddress = new Uri("https://localhost:44393/"));
            builder.Services.AddHttpClient<IMachineDataService, MachineDataService>(client => client.BaseAddress = new Uri("https://machinblazorapi.azurewebsites.net"));

        
            await builder.Build().RunAsync();
        } 
    }
}
