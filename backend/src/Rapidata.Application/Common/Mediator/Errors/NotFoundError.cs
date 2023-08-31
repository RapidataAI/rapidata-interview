namespace Rapidata.Application.Common.Mediator.Errors;

public class NotFoundError : BaseError
{
    public NotFoundError(string message) : base(message, ErrorType.NotFound)
    {
    }

}
