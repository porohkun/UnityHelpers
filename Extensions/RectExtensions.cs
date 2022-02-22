using System.Collections.Generic;

namespace UnityEngine
{
    public static class RectExtensions
    {
        public static IEnumerable<Vector2> GetCorners(this Rect rect)
        {
            yield return new Vector2(rect.xMin, rect.yMin);
            yield return new Vector2(rect.xMin, rect.yMax);
            yield return new Vector2(rect.xMax, rect.yMax);
            yield return new Vector2(rect.xMax, rect.yMin);
        }

        public static void GetCorners(this Rect rect, ref Vector2[] corners)
        {
            corners[0] = new Vector2(rect.xMin, rect.yMin);
            corners[1] = new Vector2(rect.xMin, rect.yMax);
            corners[2] = new Vector2(rect.xMax, rect.yMax);
            corners[3] = new Vector2(rect.xMax, rect.yMin);
        }
    }
}
