using UnityEngine;

public class InstantiateOnEnable : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private bool _autoDisable;

    private void OnEnable()
    {
        Instantiate(_prefab).transform.position = transform.position;
        if (_autoDisable)
            gameObject.SetActive(false);
    }
}

