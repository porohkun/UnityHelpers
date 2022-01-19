using UnityEngine;

namespace Helpers
{
    public class LimitRotation : MonoBehaviour
    {
        [SerializeField] private float _limitAngle;
        private Rigidbody _rigidbody;

        private void Reset()
        {
            this.FindAndAssignComponent(ref _rigidbody, true);
        }

        private void Awake()
        {
            this.FindAndAssignComponent(ref _rigidbody, true);
        }

        void FixedUpdate()
        {
            {
                var limitDir = Vector3.up;
                var dir = transform.up;

                var angle = Vector3.Angle(dir, limitDir);

                if (angle > _limitAngle)
                {
                    var lerp = Quaternion.Lerp(transform.rotation, Quaternion.identity, (angle - _limitAngle) / angle);
                    _rigidbody.MoveRotation(lerp);
                }
            }
            {
                var limitDir = Vector3.forward;
                var dir = transform.forward;

                var angle = Vector3.Angle(dir, limitDir);

                if (angle > _limitAngle)
                {
                    var lerp = Quaternion.Lerp(transform.rotation, Quaternion.identity, (angle - _limitAngle) / angle);
                    _rigidbody.MoveRotation(lerp);
                }
            }
        }
    }
}
