#if ZENJECT
using System;
using System.Linq;
using System.Reflection;

namespace Zenject
{
    public class ZenjectBindingFactory : Attribute
    {
        public readonly Type FactoryType;

        public ZenjectBindingFactory(Type factoryType = null)
        {
            FactoryType = factoryType;
        }

        public static void Bind(Type[] types, DiContainer container)
        {
            var method = container.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance).Where(m => m.Name == "BindIFactory" && m.IsGenericMethod && m.GetGenericArguments().Length == 1).FirstOrDefault();
            foreach (var type in types.Where(t => t.CustomAttributes.Any(a => a.AttributeType == typeof(ZenjectBindingFactory))))
                method.MakeGenericMethod(type).Invoke(container, null);
        }
    }
}
#endif
