using System.Reflection;
using Rapidata.Application.Common.Constants;
namespace Rapidata.Application.Common.ServiceLocation;

public static class RapidataServiceLocator
{
    public static IEnumerable<Assembly> GetAllAssemblies()
    {
        return AppDomain
            .CurrentDomain
            .GetAssemblies()
            .Where(x =>
                x.FullName != null &&
                x.FullName.StartsWith(ApplicationConstants.ApplicationName, StringComparison.Ordinal));
    }

    private static IEnumerable<Type> GetAllTypes()
    {
        return GetAllAssemblies()
            .SelectMany(x => x.GetExportedTypes());
    }

    public static IEnumerable<Type> GetAllConcreteTypesImplementingInterface(Type interfaceType)
    {
        return GetAllTypes()
            .Where(x =>
                x.IsClass &&
                !x.IsAbstract &&
                !x.IsGenericType &&
                x.GetInterfaces()
                    .Contains(interfaceType));
    }

    public static IEnumerable<Type> GetAllConcreteTypesImplementingGenericInterface(Type openGenericType)
    {
        return GetAllAssemblies()
            .SelectMany(x => x.GetAllTypesImplementingGenericInterface(openGenericType));
    }
}
