using FluentAssertions;
using Rapidata.Application.Commands.Orders.OrderProducts;
namespace Rapidata.Application.UnitTests.Commands.OrderProducts;

public class OrderProductsCommandValidatorTests : BaseTest<OrderProductsCommandValidator>
{
    [Test]
    public async Task Validate_WhenOrderContainsNoProducts_ShouldHaveError()
    {
        // Arrange
        var command = new OrderProductsCommand
        {
            Products = new List<OrderProductsCommand.Product>()
        };
        
        // Act
        var result = await Subject.ValidateAsync(command);
        
        // Assert
        result.IsValid.Should().BeFalse();
    }
    
    [Test]
    public async Task Validate_WhenContainsProducts_ShouldHaveNoError()
    {
        // Arrange
        var command = new OrderProductsCommand
        {
            Products = new List<OrderProductsCommand.Product>()
            {
                new OrderProductsCommand.Product()
            }
        };
        
        // Act
        var result = await Subject.ValidateAsync(command);
        
        // Assert
        result.IsValid.Should().BeTrue();
    }
}
