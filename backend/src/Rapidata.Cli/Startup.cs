using MediatR;
using Microsoft.Extensions.Hosting;
using Rapidata.Application.Commands.Orders.OrderProducts;
namespace Rapidata.Cli;

public class Startup : IHostedService
{
    private readonly string[] _args;
    private readonly IMediator _mediator;

    public Startup(IMediator mediator, string[] args)
    {
        _mediator = mediator;
        _args = args;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new OrderProductsCommand()
        {
            Products = new List<OrderProductsCommand.Product>()
            {
                new ()
                {
                    Amount = 10,
                    ProductId = "64d4c914f54144aae292cd69"
                }
            }
        }).ConfigureAwait(false);

        if (result.IsFailure)
        {
            Console.WriteLine("Failed to order products" + result.Error!.Message);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    
}
