using System.Text.Json.Serialization;
namespace Rapidata.Application.Common.Mediator.Errors;

public abstract class BaseError
{
    protected BaseError(string message, ErrorType type)
    {
        Message = message;
        Type = type;
    }

    [JsonPropertyName("errorType")]
    public ErrorType Type { get; }

    [JsonPropertyName("errorMessage")]
    public string Message { get; }
}
