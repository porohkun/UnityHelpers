#if ZENJECT
using System;
using System.Collections.Generic;

namespace Zenject
{

    public static class ZenjectSingleInstances
    {
        private static readonly Dictionary<Type, object> _instances = new Dictionary<Type, object>();

        public static void Add(object instance)
        {
            var type = instance.GetType();
            _instances[type] = instance;
        }

        public static void Add(IEnumerable<object> instances)
        {
            foreach (var instance in instances)
                Add(instance);
        }

        public static T Get<T>()
        {
            var type = typeof(T);
            return (T)_instances[type];
        }

        public static bool Have<T>()
        {
            return _instances.ContainsKey(typeof(T));
        }
    }
}
#endif