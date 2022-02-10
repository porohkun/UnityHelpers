using UnityEngine;

namespace Helpers
{
    public static class Movement
    {
        public static Vector3 LinearMove(Vector3 position, Vector3 target, float speed, out bool moved, float deltaTime, float stopAccuracy = 0.01f)
        {
            var fakeDirection = Vector3.zero;
            return LinearMove(position, target, ref fakeDirection, speed, out moved, deltaTime, 1, stopAccuracy);
        }

        public static Vector2 LinearMove(Vector2 position, Vector2 target, float speed, out bool moved, float deltaTime, float stopAccuracy = 0.01f)
        {
            var fakeDirection = Vector2.zero;
            return LinearMove(position, target, ref fakeDirection, speed, out moved, deltaTime, 1, stopAccuracy);
        }

        public static float LinearMove(float position, float target, float speed, out bool moved, float deltaTime, float stopAccuracy = 0.01f)
        {
            var fakeDirection = 0f;
            return LinearMove(position, target, ref fakeDirection, speed, out moved, deltaTime, 1, stopAccuracy);
        }

        public static Vector3 LinearMove(Vector3 position, Vector3 target, ref Vector3 direction, float speed, out bool moved, float deltaTime, float turnPower = 1f, float stopAccuracy = 0.01f)
        {
            turnPower = Mathf.Clamp01(turnPower);
            var newDirection = target - position;
            direction = direction * (1 - turnPower) + newDirection * turnPower;
            if (direction.sqrMagnitude > stopAccuracy * stopAccuracy)
            {
                var step = speed * Mathf.Sqrt(direction.magnitude) * deltaTime;
                if (direction.sqrMagnitude < step * step)
                    position = target;
                else
                    position += direction.normalized * step;
                moved = true;
            }
            else
                moved = false;
            return position;
        }

        public static Vector2 LinearMove(Vector2 position, Vector2 target, ref Vector2 direction, float speed, out bool moved, float deltaTime, float turnPower = 1f, float stopAccuracy = 0.01f)
        {
            turnPower = Mathf.Clamp01(turnPower);
            var newDirection = target - position;
            direction = direction * (1 - turnPower) + newDirection * turnPower;
            if (direction.sqrMagnitude > stopAccuracy * stopAccuracy)
            {
                var step = speed * Mathf.Sqrt(direction.magnitude) * deltaTime;
                if (direction.sqrMagnitude < step * step)
                    position = target;
                else
                    position += direction.normalized * step;
                moved = true;
            }
            else
                moved = false;
            return position;
        }

        public static float LinearMove(float position, float target, ref float direction, float speed, out bool moved, float deltaTime, float turnPower = 1f, float stopAccuracy = 0.01f)
        {
            turnPower = Mathf.Clamp01(turnPower);
            var newDirection = target - position;
            direction = direction * (1 - turnPower) + newDirection * turnPower;
            if (Mathf.Abs(direction) > stopAccuracy)
            {
                var step = speed * Mathf.Sqrt(Mathf.Abs(direction)) * deltaTime;
                if (Mathf.Abs(direction) < step)
                    position = target;
                else
                    position += Mathf.Sign(direction) * step;
                moved = true;
            }
            else
                moved = false;
            return position;
        }
    }
}
