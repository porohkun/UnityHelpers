using UnityEngine;

namespace Helpers
{
    public class SmoothValue
    {
        public float Value { get; private set; }
        public float Target { get; set; }
        public float Speed { get; set; } = 1f;

        public SmoothValue(float value, float target)
        {
            Value = value;
            Target = target;
        }

        public void Force(float value)
        {
            Value = value;
            Target = value;
        }

        public void Update(float deltaTime)
        {
            var direction = Target - Value;
            var step = deltaTime * direction * Speed * Mathf.Sqrt(Mathf.Abs(direction));
            if (Mathf.Abs(step) < Mathf.Abs(direction))
                Value += step;
        }

        public static implicit operator float(SmoothValue value)
        {
            return value.Value;
        }
    }
}
