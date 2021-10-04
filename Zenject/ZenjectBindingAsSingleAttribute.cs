#if ZENJECT
using System;
using System.Linq;

namespace Zenject
{
    public class ZenjectBindingAsSingleAttribute : Attribute
    {
        public readonly Type FactoryType;

        public ZenjectBindingAsSingleAttribute(Type factoryType = null)
        {
            FactoryType = factoryType;
        }

        public static void Bind(Type[] types, DiContainer container)
        {
            foreach (var type in types.Where(t => t.CustomAttributes.Any(a => a.AttributeType == typeof(ZenjectBindingAsSingleAttribute))))
                container.BindInterfacesAndSelfTo(type).AsSingle();
        }
    }
}
#endif