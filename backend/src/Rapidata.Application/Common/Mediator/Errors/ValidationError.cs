using FluentValidation.Results;
namespace Rapidata.Application.Common.Mediator.Errors;

public class ValidationError : BaseError
{
    public ValidationError(IList<ValidationFailure> failures) : base("A validation error occurred.",
        ErrorType.Validation)
    {
        Errors = failures.Select(f => new PropertyError(f.PropertyName, f.ErrorMessage)).ToList();
    }

    public IList<PropertyError> Errors { get; set; }

    public class PropertyError
    {
        public PropertyError(string propertyName, string errorMessage)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
        }

        public string PropertyName { get; }
        public string ErrorMessage { get; }
    }
}
