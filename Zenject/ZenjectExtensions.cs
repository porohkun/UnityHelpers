#if ZENJECT
using System;
using System.Linq;

namespace Zenject
{
    public static class ZenjectExtensions
    {
        public static ScopeConcreteIdArgConditionCopyNonLazyBinder FromFactory(this FromBinderNonGeneric binder, Type tConcrete, Type tFactory)
        {
            var factoryInterface = typeof(IFactory<>).MakeGenericType(tConcrete);
            if (!factoryInterface.IsAssignableFrom(tFactory))
                throw new ArgumentException();
            var method = typeof(FromBinderNonGeneric).GetMethods().Where(m =>
                m.Name == nameof(FromBinderNonGeneric.FromFactory)
                && m.GetParameters().Length == 0
                && m.GetGenericArguments().Length == 2).First();
            return (ScopeConcreteIdArgConditionCopyNonLazyBinder)method.MakeGenericMethod(tConcrete, tFactory).Invoke(binder, null);
        }
    }
}
#endif