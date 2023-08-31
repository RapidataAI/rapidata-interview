using FluentValidation;
using Rapidata.Application.Common.Validation;
namespace Rapidata.Application.Commands.Orders.OrderProducts;

public class OrderProductsCommandValidator : CommandValidator<OrderProductsCommand>
{
    public OrderProductsCommandValidator()
    {
        /*
         * This is an example for guidance.
         * RuleFor(x => x.SomeProperty).NotEmpty();
         * Child Rules can be created like this: RuleForEach(x => x.Products).ChildRules(products => { ... });
         */
        RuleFor(x => x.Products).NotEmpty();
    }
}
