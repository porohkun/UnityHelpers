using System;
using System.Collections.Generic;

namespace UnityEngine
{
    public static class VectorExtension
    {
        public static Vector3 Scaled(this Vector3 vector, float x, float y, float z)
        {
            return new Vector3(vector.x * x, vector.y * y, vector.z * z);
        }

        /// <summary>
        /// {X, Z}
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Vector2 ToVector2(this Vector3 vector)
        {
            return new Vector2(vector.x, vector.z);
        }

        public static Vector2 ToVector2(this Vector2Int vector)
        {
            return new Vector2(vector.x, vector.y);
        }

        public static Vector3 AddY(this Vector2 vector, float y = 0f)
        {
            return new Vector3(vector.x, y, vector.y);
        }

        public static Vector3 AddY(this Vector2Int vector, float y = 0)
        {
            return new Vector3(vector.x, y, vector.y);
        }

        public static Vector3 SetY(this Vector3 vector, float y)
        {
            return new Vector3(vector.x, y, vector.z);
        }

        public static float DistanceTo(this Vector3 vector, Vector3 other)
        {
            return Vector3.Distance(vector, other);
        }

        public static float DistanceTo(this Vector2 vector, Vector2 other)
        {
            return Vector2.Distance(vector, other);
        }

        public static Vector3 Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, Vector3> selector)
        {
            var x = 0f;
            var y = 0f;
            var z = 0f;
            foreach (var entry in source)
            {
                var vector = selector.Invoke(entry);
                x += vector.x;
                y += vector.y;
                z += vector.z;
            }
            return new Vector3(x, y, z);
        }

        public static Vector2 Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, Vector2> selector)
        {
            var x = 0f;
            var y = 0f;
            foreach (var entry in source)
            {
                var vector = selector.Invoke(entry);
                x += vector.x;
                y += vector.y;
            }
            return new Vector2(x, y);
        }
    }
}
