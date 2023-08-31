namespace Rapidata.Application.Common.Mediator.Errors;

/// <summary>
///     The Result Type allows the object to take two different states. This is used within the CommandHandler.
///     A Command Handler can Fail and it is normal for him to do so. For ease of implementation the Command Handler
///     can directly return an Error. This Error is then wrapped in a Result Type. If everything is as expected he
///     can return the Value, which is also wrapped in the Result Type.
/// </summary>
/// <typeparam name="TValue"></typeparam>
/// <typeparam name="TError"></typeparam>
public readonly struct Result<TValue, TError> : IResult<TValue, TError>
{
    public TValue? Value { get; }
    public TError? Error { get; }

    private Result(TValue value)
    {
        Value = value;
        Error = default!;
        IsSuccess = true;
    }

    private Result(TError error)
    {
        Value = default!;
        Error = error;
        IsSuccess = false;
    }


    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

    public static implicit operator Result<TValue, TError>(TValue value)
    {
        return new Result<TValue, TError>(value);
    }
    public static implicit operator Result<TValue, TError>(TError error)
    {
        return new Result<TValue, TError>(error);
    }

    public TResponse Match<TResponse>(Func<TValue, TResponse> onSuccess, Func<TError, TResponse> onFailure)
    {
        return IsSuccess ? onSuccess(Value!) : onFailure(Error!);
    }
}

public interface IResult<out TValue, out TError>
{
    public TValue? Value { get; }
    public TError? Error { get; }
    public bool IsSuccess { get; }
    public bool IsFailure { get; }

    TResponse Match<TResponse>(Func<TValue, TResponse> onSuccess, Func<TError, TResponse> onFailure);
}
