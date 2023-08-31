using Rapidata.Application.Common.Mediator;
using Rapidata.Application.Common.Mediator.Errors;
namespace Rapidata.Application.Commands.Orders.OrderProducts;

public class OrderProductsCommandHandler : ICanFailRequestHandler<OrderProductsCommand, OrderProductsResult>
{
    public Task<Result<OrderProductsResult, BaseError>> Handle(OrderProductsCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
