using FunctionApp.Configurations;

using Microsoft.Azure.Functions.Worker.Extensions.OpenApi.Extensions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Configurations.AppSettings.Extensions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
               .ConfigureAppConfiguration((context, config) =>
               {
                   config.AddEnvironmentVariables();
               })
               .ConfigureFunctionsWorkerDefaults(worker => worker.UseNewtonsoftJson())
               .ConfigureServices(services =>
               {
                   var settings = services.BuildServiceProvider()
                                          .GetService<IConfiguration>()
                                          .Get<GraphSettings>(GraphSettings.Name);

                   services.AddSingleton(settings);

                   services.AddSingleton<IOpenApiConfigurationOptions>(_ =>
                            {
                                var options = new DefaultOpenApiConfigurationOptions();

                                /* ⬇️⬇️⬇️ for GH Codespaces ⬇️⬇️⬇️ */
                                var codespaces = bool.TryParse(Environment.GetEnvironmentVariable("OpenApi__RunOnCodespaces"), out var isCodespaces) && isCodespaces;
                                if (codespaces)
                                {
                                    options.IncludeRequestingHostName = false;
                                }
                                /* ⬆️⬆️⬆️ for GH Codespaces ⬆️⬆️⬆️ */

                                return options;
                            });
               })
               .Build();

host.Run();