namespace Rapidata.Application.Common.Mediator.Errors;

public class RuntimeError : BaseError
{
    public RuntimeError(string message) : base(message, ErrorType.Runtime)
    {
    }
}
