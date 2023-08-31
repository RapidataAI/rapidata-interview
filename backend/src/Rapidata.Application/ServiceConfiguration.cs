using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rapidata.Application.Common.Mediator;
using Rapidata.Application.Common.Mediator.Behaviours;
using Rapidata.Application.Common.Validation;
namespace Rapidata.Application;

public static class ServiceConfiguration
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddHttpClient();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddScoped(typeof(IValidationAggregator<>), typeof(ValidationAggregator<>));


        RegisterBehaviours(services);

#if DEBUG
        WarnDeveloperIfRequestHasValidatorButIsNotFallible(services);
#endif

        return services;
    }
    private static void WarnDeveloperIfRequestHasValidatorButIsNotFallible(IServiceCollection services)
    {
        var validators = services.Where(x =>
            x.ServiceType.IsGenericType && x.ServiceType.GetGenericTypeDefinition() == typeof(IValidator<>));

        foreach (var service in validators)
        {
            var typeToValidate = service.ServiceType.GetGenericArguments()[0];

            if (!typeToValidate.IsAssignableTo(typeof(IBaseRequest)))
            {
                continue;
            }

            if (!typeToValidate.IsAssignableTo(typeof(ICanFailBaseRequest)))
            {
                Console.WriteLine(
                    $"Warning: {typeToValidate.Name} has a validator but does not implement {nameof(ICanFailBaseRequest)}. The Validator will not be called before executing the Handler.");
            }
        }
    }

    private static void RegisterBehaviours(IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
    }
}
