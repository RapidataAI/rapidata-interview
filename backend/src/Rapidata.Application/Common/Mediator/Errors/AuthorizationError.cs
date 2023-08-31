namespace Rapidata.Application.Common.Mediator.Errors;

public class AuthorizationError : BaseError
{
    public AuthorizationError(string message) : base(message, ErrorType.Authorization)
    {
    }
}
