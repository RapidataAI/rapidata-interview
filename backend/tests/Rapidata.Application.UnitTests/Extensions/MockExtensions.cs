using MediatR;
using Moq;
using Moq.Language;
using Moq.Language.Flow;
using Rapidata.Application.Common.Mediator.Errors;
namespace Rapidata.Application.UnitTests.Extensions;

public static class MockExtensions
{
    public static IReturnsResult<TMock> ReturnsResultAsync<TMock, TResult>(
        this IReturns<TMock, Task<Result<TResult, BaseError>>> mock,
        TResult value)
        where TMock : class, IMediator
        where TResult : class
    {
        return mock.ReturnsAsync(() => CreateResult(value));
    }
    
    public static IReturnsResult<TMock> ReturnsErrorAsync<TMock, TResult>(
        this IReturns<TMock, Task<Result<TResult, BaseError>>> mock,
        BaseError value)
        where TMock : class, IMediator
        where TResult : class
    {
        return mock.ReturnsAsync(() => CreateError<TResult>(value));
    }

    private static Result<TResponse, BaseError> CreateResult<TResponse>(TResponse value)
        where TResponse : class
    {
        return value;
    }
    
    private static Result<TResponse, BaseError> CreateError<TResponse>(BaseError error)
        where TResponse : class
    {
        return error;
    }
}
