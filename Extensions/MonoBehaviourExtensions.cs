﻿namespace UnityEngine
{
    public static class MonoBehaviourExtensions
    {
        public static void FindAndAssignComponent<T>(this MonoBehaviour mb, ref T component, bool replaceIfNotNull = false) where T : Component
        {
            if (!component || replaceIfNotNull)
            {
                component = mb.GetComponentInChildren<T>();
            }
            if (component == null)
            {
                Debug.LogWarning($"No {typeof(T)} find on {mb.name}", mb.gameObject);
            }
        }

        public static void DestroyGameObject(this Component comp)
        {
            GameObject.Destroy(comp.gameObject);
        }
    }
}
