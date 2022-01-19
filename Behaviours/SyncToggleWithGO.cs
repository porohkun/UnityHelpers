using UnityEngine;
using UnityEngine.UI;

namespace Helpers
{
    public class SyncToggleWithGO : MonoBehaviour
    {
        [SerializeField] private GameObject _target;

        private Toggle _toggle;

        private void Reset()
        {
            this.FindAndAssignComponent<Toggle>(ref _toggle, true);
        }

        private void Awake()
        {
            this.FindAndAssignComponent<Toggle>(ref _toggle);
        }

        private void Update()
        {
            if (_toggle.isOn != _target.activeSelf)
                _toggle.isOn = _target.activeSelf;
        }
    }
}
