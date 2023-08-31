using FluentValidation.Results;
namespace Rapidata.Application.Common.Mediator.Behaviours;

/// <summary>
///     The Validation Aggregator is used to aggregate all validation errors from all validators for a given entity.
///     For a Validator to be recognized by the Validation Aggregator, it must be registered in the DI container with
///     the service Type IValidator<TEntity>.
/// </summary>
/// <typeparam name="TEntity">Any Entity having a registered IValidator</typeparam>
public interface IValidationAggregator<in TEntity>
{
    Task<IList<ValidationFailure>> Validate(TEntity entity, CancellationToken cancellationToken = default);
}
