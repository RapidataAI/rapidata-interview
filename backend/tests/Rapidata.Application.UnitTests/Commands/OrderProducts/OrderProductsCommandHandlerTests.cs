using FluentAssertions;
using MongoDB.Bson;
using Moq;
using Rapidata.Application.Commands.Orders.OrderProducts;
using Rapidata.Application.Repositories;
namespace Rapidata.Application.UnitTests.Commands.OrderProducts;

public class OrderProductsCommandHandlerTests : BaseTest<OrderProductsCommandHandler>
{
    [Test]
    public async Task Handle_WhenOneProductGiven_ReducesStockByOne()
    {
        // Arrange
        var command = new OrderProductsCommand
        {
            Products = new List<OrderProductsCommand.Product>()
            {
                new OrderProductsCommand.Product()
                {
                    Amount = 1,
                    ProductId = ObjectId.GenerateNewId().ToString(),
                }
            }
        };
        
        // Act
        await Subject.Handle(command, CancellationToken.None);
        
        // Assert
        Mock<IProductRepository>()
            .Verify(x => x.TryClaimingStockAsync(command.Products.First().ProductId, command.Products.First().Amount), Times.Once);
    }
    
    [Test]
    public async Task Handle_WhenTwoProductsGiven_ReducesStockForBoth()
    {
        throw new NotImplementedException();
    }
    
    [Test]
    public async Task Handle_WhenOneProductGivenAndStockIsNotAvailable_SendsMailToAdmin()
    {
        throw new NotImplementedException();
    }
    
    [Test]
    public async Task Handle_WhenOrderSubmitted_AddsCurrentTimestampToOrder()
    {
        throw new NotImplementedException();
    }
}
