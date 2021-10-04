using System.Collections.Generic;
using UnityEngine;

namespace System.Linq
{
    public static class LinqExtensions
    {
        public static IEnumerable<T> Union<T>(this IEnumerable<T> collection, T item)
        {
            foreach (var entry in collection)
                yield return entry;
            yield return item;
        }

        public static IEnumerable<T> Except<T>(this IEnumerable<T> collection, T item)
        {
            foreach (var entry in collection)
            {
                if (entry == null && item == null)
                    continue;
                if (entry != null && entry.Equals(item))
                    continue;
                yield return entry;
            }
        }

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var entry in collection)
            {
                action?.Invoke(entry);
                yield return entry;
            }
        }

        public static int Iterate<T>(this IEnumerable<T> collection)
        {
            var count = 0;
            foreach (var item in collection)
                count++;
            return count;
        }

        public static IEnumerable<T> Enumerate<T>(this IEnumerator<T> enumerator)
        {
            while (enumerator.MoveNext())
                yield return enumerator.Current;
        }

        public static IEnumerable<T> Enumerate<T>(this T item)
        {
            yield return item;
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this TSource[,] source, Func<TSource, int, int, TResult> selector)
        {
            var length0 = source.GetLength(0);
            var length1 = source.GetLength(1);
            for (int i = 0; i < length0; i++)
                for (int j = 0; j < length1; j++)
                    yield return selector.Invoke(source[i, j], i, j);
        }

        public static void CopyTo<T>(this T[,] source, T[,] target)
        {
            var length0 = source.GetLength(0);
            var length1 = source.GetLength(1);

            var tlength0 = target.GetLength(0);
            var tlength1 = target.GetLength(1);

            for (int i = 0; i < Math.Min(length0, tlength0); i++)
                for (int j = 0; j < Math.Min(length1, tlength1); j++)
                    target[i, j] = source[i, j];
        }

        public static void AddDistinct<T>(this IList<T> list, T item)
        {
            if (!list.Contains(item))
                list.Add(item);
        }

        public static int IndexOf<T>(this T[] array, T item)
        {
            for (int i = 0; i < array.Length; i++)
                if (array[i].Equals(item))
                    return i;
            return -1;
        }

        public static Vector2 Average<TSource>(this IEnumerable<TSource> source, Func<TSource, Vector2> selector)
        {
            var sum = Vector2.zero;
            var count = 0;

            foreach (var entry in source)
            {
                sum += selector(entry);
                count++;
            }

            return count > 0 ? sum / count : sum;
        }

        public static Vector3 Average<TSource>(this IEnumerable<TSource> source, Func<TSource, Vector3> selector)
        {
            var sum = Vector3.zero;
            var count = 0;

            foreach (var entry in source)
            {
                sum += selector(entry);
                count++;
            }

            return count > 0 ? sum / count : sum;
        }
    }
}
