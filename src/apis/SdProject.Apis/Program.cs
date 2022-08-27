using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace SdProject.Apis
{
    public class Program
    {
        #region Methods

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .ConfigureAppConfiguration(configurationBuilder =>
                        {
                            // Get the environment variable which is attached to application.
                            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                            var applicationConfigurationFile =
                                Environment.GetEnvironmentVariable("APPLICATION_CONFIGURATION_FILE");

                            var index = 0;
                            while (index < configurationBuilder.Sources.Count)
                            {
                                var configurationSource = configurationBuilder.Sources[index];
                                if (!(configurationSource is JsonConfigurationSource))
                                {
                                    index++;
                                    continue;
                                }

                                configurationBuilder.Sources.RemoveAt(index);
                            }

                            // Configuration build up.
                            configurationBuilder
                                .SetBasePath(Directory.GetCurrentDirectory());

                            // Add local appsettings.json file.
                            configurationBuilder.AddJsonFile("appsettings.json", false, true)
                                .AddJsonFile("api-documentation.json", true)
                                .AddJsonFile($"api-documentation.{environment}.json", true)
                                .AddJsonFile("cors-policies.json", true)
                                .AddJsonFile($"cors-policies.{environment}.json", true);

                            if ("Development".Equals(environment, StringComparison.InvariantCultureIgnoreCase))
                            {
                                configurationBuilder
                                    .AddJsonFile($"appsettings.{environment}.json", true, true)
                                    .AddUserSecrets<Startup>(true, true);

                                if (File.Exists(applicationConfigurationFile))
                                    configurationBuilder.AddJsonFile(applicationConfigurationFile, true, true);
                            }
                            else if (!string.IsNullOrWhiteSpace(environment))
                            {
                                if (File.Exists(applicationConfigurationFile))
                                    configurationBuilder.AddJsonFile(applicationConfigurationFile, true, true);

                                configurationBuilder
                                    .AddJsonFile($"appsettings.{environment}.json", true, true);
                            }
                            else
                            {
                                if (File.Exists(applicationConfigurationFile))
                                    configurationBuilder.AddJsonFile(applicationConfigurationFile, true, true);
                            }
                        })
                        .UseSerilog((context, configuration) => new LoggerConfiguration()
                            .ReadFrom.Configuration(context.Configuration))
                        .UseStartup<Startup>();
                });
        }

        #endregion
    }
}