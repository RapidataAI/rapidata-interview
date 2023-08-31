namespace Rapidata.Application.Repositories;

public interface IProductRepository
{
    Task<bool> TryClaimingStockAsync(string productId, int quantity);
}
