using FluentValidation;
using Rapidata.Application.Common.Mediator;
namespace Rapidata.Application.Common.Validation;

/// <summary>
///     The RapidataValidator is a directly derived class from AbstractValidator. It only Adds the ICanFailBaseRequest
///     interface to the generic type.
///     This ensures that the Developer is using the the correct Request type which is a Fallible Request. As soon as a
///     Validator is introduced.
///     He can fail and is therefore required to be of the Type ICanFailBaseRequest. If a validator is required for
///     something outside
///     of Command / Command Handlers, it is recommended to use the AbstractValidator directly.
/// </summary>
/// <typeparam name="T">The Type that can be validated.</typeparam>
public abstract class CommandValidator<T> : AbstractValidator<T>
    where T : ICanFailBaseRequest
{
}
