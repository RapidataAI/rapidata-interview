namespace Rapidata.Application.Common.ServiceLocation;

public class TypeResolvingException : Exception
{
    public TypeResolvingException()
    {
    }

    public TypeResolvingException(string message) : base(message)
    {
    }

    public TypeResolvingException(string message, Exception inner) : base(message, inner)
    {
    }
}
