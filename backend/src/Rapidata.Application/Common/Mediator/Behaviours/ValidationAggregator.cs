using FluentValidation;
using FluentValidation.Results;
namespace Rapidata.Application.Common.Mediator.Behaviours;

public class ValidationAggregator<TEntity> : IValidationAggregator<TEntity>
{
    private readonly IEnumerable<IValidator<TEntity>> _validators;

    public ValidationAggregator(IEnumerable<IValidator<TEntity>> validators)
    {
        _validators = validators;
    }

    public async Task<IList<ValidationFailure>> Validate(TEntity entity, CancellationToken cancellationToken = default)
    {
        var context = new ValidationContext<TEntity>(entity);

        var validationResults = await Task.WhenAll(
            _validators.Select(v =>
                v.ValidateAsync(context, cancellationToken))).ConfigureAwait(false);

        return validationResults
            .Where(r => r.Errors.Any())
            .SelectMany(r => r.Errors)
            .ToList();
    }
}
