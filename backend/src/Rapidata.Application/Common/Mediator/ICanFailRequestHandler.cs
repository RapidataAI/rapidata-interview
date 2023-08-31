using MediatR;
using Rapidata.Application.Common.Mediator.Errors;
namespace Rapidata.Application.Common.Mediator;

public interface ICanFailRequestHandler<in TRequest> : IRequestHandler<TRequest, Result<Unit, BaseError>>
    where TRequest : ICanFailRequest, IRequest<Result<Unit, BaseError>>
{
}

public interface
    ICanFailRequestHandler<in TRequest, TResponse> : IRequestHandler<TRequest, Result<TResponse, BaseError>>
    where TRequest : ICanFailRequest<TResponse>, IRequest<Result<TResponse, BaseError>>
{
}
