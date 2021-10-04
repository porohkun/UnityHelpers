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
}

