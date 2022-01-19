namespace UnityEngine
{
    [ExecuteInEditMode]
    public class SnapToGrid : MonoBehaviour
    {
        [SerializeField] private Vector3Int _grid;

        private void Awake()
        {
            if (Application.isPlaying)
                enabled = false;
        }

        private void Update()
        {
            var pos = transform.localPosition;
            transform.localPosition = new Vector3(
                _grid.x == 0 ? pos.x : Mathf.Round(pos.x / _grid.x) * _grid.x,
                _grid.y == 0 ? pos.y : Mathf.Round(pos.y / _grid.y) * _grid.y,
                _grid.z == 0 ? pos.z : Mathf.Round(pos.z / _grid.z) * _grid.z);
        }

    }
}
