using System;
using System.Collections;
using UnityEngine;

public static class Miscoroutines
{
    public static IEnumerator WaitRoutine(float delay, Action callback)
    {
        yield return new WaitForSeconds(delay);
        callback?.Invoke();
    }

    public static IEnumerator WaitNextFrameRoutine(Action callback)
    {
        yield return null;
        callback?.Invoke();
    }

    public static IEnumerator WaitWhileRoutine(Func<bool> predicate, Action callback)
    {
        yield return new WaitWhile(predicate);
        callback?.Invoke();
    }

    public static IEnumerator Tween(float duration, Action<float> progress, Action completed)
    {
        var time = 0f;
        var maxTime = duration;
        do
        {
            yield return null;
            time += Time.deltaTime;
            var t = time / maxTime;

            progress?.Invoke(t);
        }
        while (time <= maxTime);
        completed?.Invoke();
    }
}
