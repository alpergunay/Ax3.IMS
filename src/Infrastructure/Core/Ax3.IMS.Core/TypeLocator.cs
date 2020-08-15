using System;
using System.Linq;
using System.Reflection;

namespace Ax3.IMS.Infrastructure.Core
{
    public static class TypeLocator
    {
        public static Assembly GetEntryPointAssembly(Type type)
        {
            return GetTypeEntryPointAssembly(type);
        }

        public static Assembly GetTypeEntryPointAssembly(Type baseType)
        {
            var assembly = Assembly.GetEntryAssembly();
            if (assembly != null)
            {
                return assembly;
            }

            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes().Where(t => t.IsSubclassOf(baseType)))
                .ToList();
            var type = types.FirstOrDefault(t => !types.Any(x => x.IsSubclassOf(t)));
            if (type == null)
            {
                throw new InvalidOperationException($"Unable to locate EntryPointAssembly with type {baseType}");
            }

            return type.Assembly;
        }
    }
}