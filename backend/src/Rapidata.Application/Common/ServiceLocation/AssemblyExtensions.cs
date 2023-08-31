using System.Reflection;
namespace Rapidata.Application.Common.ServiceLocation;

public static class AssemblyExtensions
{
    public static IEnumerable<Type> GetAllTypesImplementingGenericInterface(this Assembly assembly,
        Type openGenericType)
    {
        ThrowIfIsNotOpenGenericInterface(openGenericType);

        return assembly.GetTypes().Where(x => DoesImplementGenericInterface(x, openGenericType));
    }

    public static bool DoesImplementGenericInterface(this Type type, Type openGenericType)
    {
        ThrowIfIsNotOpenGenericInterface(openGenericType);

        return !type.IsAbstract &&
               type.IsClass &&
               type.GetInterfaces()
                   .Any(i => i.IsGenericType && i.GetGenericTypeDefinition().IsAssignableFrom(openGenericType));
    }

    public static Type[] GetGenericTypeArgumentsOfImplementedInterface(this Type type, Type openGenericType)
    {
        ThrowIfIsNotOpenGenericInterface(openGenericType);

        return type.GetInterfaces()
            .First(x => x.IsGenericType && x.GetGenericTypeDefinition().IsAssignableFrom(openGenericType))
            .GetGenericArguments();
    }

    private static void ThrowIfIsNotOpenGenericInterface(Type type)
    {
        if (!type.IsInterface || !type.IsGenericTypeDefinition)
        {
            throw new ArgumentException(
                "The type supplied doesn't either isn't an interface or doesn't contain Generic type definitions. Type: ",
                nameof(type));
        }
    }
}
