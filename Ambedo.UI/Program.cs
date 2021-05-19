using Ambedo.UI.Data.Options;
using Ambedo.UI.Data.Services;
using Ambedo.UI.Data.Services.Interfaces;
using Blazorise;
using Blazorise.Icons.Material;
using Blazorise.Material;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluxor;
namespace Ambedo.UI
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");
			builder.Services.Configure<AmbedoAPIOptions>(c => builder.Configuration.GetSection(AmbedoAPIOptions.Key).Bind(c));
			builder.Services.AddScoped<IDataService, DataService>();
			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
			builder.Services.AddBlazorise(options =>
			{
				options.ChangeTextOnKeyPress = true;
			}).AddMaterialProviders().AddMaterialIcons();
			builder.Services.AddFluxor(options => options.ScanAssemblies(typeof(Program).Assembly).UseReduxDevTools());
			await builder.Build().RunAsync();
		}
	}
}
