using Rapidata.Application.Common.Mediator;
namespace Rapidata.Application.Commands.Orders.OrderProducts;

public class OrderProductsCommand : ICanFailRequest<OrderProductsResult>
{
    public IList<Product> Products { get; set; }

    public class Product
    {
        public string ProductId { get; set; }
        public int Amount { get; set; }
    }
}
