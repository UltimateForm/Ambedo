using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
namespace Ambedo.API
{
	public class Program
	{
		public static int Main(string[] args)
		{
			var configuration = new ConfigurationBuilder()
								.SetBasePath(Directory.GetCurrentDirectory())
								.AddJsonFile("appsettings.json")
								.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
								.Build();

			Log.Logger = new LoggerConfiguration()
								.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
								.MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                                .MinimumLevel.Debug()
								.Enrich
								.FromLogContext().WriteTo
								.Console(outputTemplate:"[{Timestamp:HH:mm:ss} {Level:u3}] {Message}{NewLine}{Exception}")
								.CreateLogger();
			try
			{
				Log.Information("Starting web host");
				CreateHostBuilder(args).Build().Run();
				return 0;
			}
			catch (System.Exception ex)
			{
				Log.Fatal(ex, "Host terminated unexpectedly");
				return 0;
			}
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
				Host.CreateDefaultBuilder(args).UseSerilog()
						.ConfigureWebHostDefaults(webBuilder =>
						{
							webBuilder.UseStartup<Startup>();
						});
	}
}
