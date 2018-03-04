using BCPAO.PhotoManager.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace BCPAO.PhotoManager
{
	public class Program
	{
		// https://docs.microsoft.com/en-us/aspnet/core/migration/1x-to-2x/#move-database-initialization-code
		public static void Main(string[] args)
		{
			var host = BuildWebHost(args);

			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;

				try
				{
					SeedData.Initialize(services);
				}
				catch (Exception ex)
				{
					var logger = services.GetRequiredService<ILogger<Program>>();
					logger.LogError(ex, "An error occurred while seeding the database.");
					//throw ex;
				}
			}

			host.Run();
		}

		public static IWebHost BuildWebHost(string[] args) =>
			 WebHost.CreateDefaultBuilder(args)
				  .UseStartup<Startup>()
				  .ConfigureAppConfiguration((hostContext, config) =>
				  {
					  // delete all default configuration providers
					  config.Sources.Clear();
					  config.AddJsonFile("appsettings.json", optional: true);
				  })
				  .Build();
	}
}
