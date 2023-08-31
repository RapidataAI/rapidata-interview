using MediatR;
using Rapidata.Application.Common.Mediator.Errors;
namespace Rapidata.Application.Common.Mediator;

public interface ICanFailRequest : ICanFailRequest<Unit>
{
}

public interface ICanFailRequest<TResponse> : IRequest<Result<TResponse, BaseError>>, ICanFailBaseRequest
{
}

public interface ICanFailBaseRequest : IBaseRequest
{
}
