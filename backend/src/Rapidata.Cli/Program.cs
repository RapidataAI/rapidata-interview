using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rapidata.Application;
using Rapidata.Cli;
using Rapidata.Infrastructure;
var builder = Host.CreateDefaultBuilder()
    .ConfigureHostConfiguration(configBuilder =>
    {
        configBuilder.AddJsonFile("appsettings.json");
    }).ConfigureServices((context, collection) =>
    {
        collection.ConfigureApplicationServices(context.Configuration);
        collection.ConfigureInfrastructureServices(context.Configuration);
        collection.ConfigureCliServices(context.Configuration);

        collection.AddSingleton<IHostedService>(sp => new Startup(sp.GetRequiredService<IMediator>(), args));
    });

var host = builder.Build();

await host.StartAsync(CancellationToken.None).ConfigureAwait(false);
