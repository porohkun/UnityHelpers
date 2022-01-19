namespace UnityEngine
{
    public static class LayerMaskExtensions
    {
        public static bool IncludesLayer(this LayerMask mask, int layer)
        {
            return (mask.value | (1 << layer)) == mask.value;
        }
    }
}
