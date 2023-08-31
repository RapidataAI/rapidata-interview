namespace Rapidata.Domain.Entities;

public class Order
{
    public string OrderId { get; set; }
    public string CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public IList<OrderProduct> Products { get; set; }
}
