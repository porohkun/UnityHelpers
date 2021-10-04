using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class RandomExtensions
{
    public static IEnumerable<T> GetRandom<T>(this IEnumerable<T> sequence, int count)
    {
        var items = sequence.ToList();
        if (items.Count <= count)
        {
            foreach (var item in items)
                yield return item;
            yield break;
        }
        while (count > 0)
        {
            var rnd = Random.Range(0, items.Count);
            yield return items[rnd];
            items.RemoveAt(rnd);
            count--;
        }
    }

    public static T GetRandom<T>(this IEnumerable<T> sequence)
    {
        var items = sequence.ToList();
        if (items.Count == 0)
            return default(T);
        return items[Random.Range(0, items.Count)];
    }

    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> sequence)
    {
        var items = sequence.ToList();
        while (items.Count > 0)
        {
            var index = Random.Range(0, items.Count);
            var result = items[index];
            items.RemoveAt(index);
            yield return result;
        }
    }
}

