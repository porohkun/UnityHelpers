#if ZENJECT
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Zenject
{
    public class ZenjectBindingInstanceAsSingleAttribute : Attribute
    {
        public static void Bind(DiContainer container)
        {
            var scene = SceneManager.GetActiveScene();
            foreach (var go in scene.GetRootGameObjects())
                InstallGameObject(go, container);
        }

        private static void InstallGameObject(GameObject go, DiContainer container)
        {
            var instances = go.GetComponents<Component>()
                .Where(c => c != null && c.GetType().CustomAttributes.Any(a => a.AttributeType == typeof(ZenjectBindingInstanceAsSingleAttribute)))
                .ToArray();
            container.BindInstances(instances);

            for (int i = 0; i < go.transform.childCount; i++)
                InstallGameObject(go.transform.GetChild(i).gameObject, container);

            ZenjectSingleInstances.Add(instances);
        }
    }
}
#endif
