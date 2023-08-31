namespace Rapidata.Domain.Entities;

public class OrderProduct
{
    public string OrderId { get; set; }
    public string ProductId { get; set; }
    public int Amount { get; set; }
}
