using UnityEngine;

public class EnableIfEditor : MonoBehaviour
{
    [SerializeField] public bool _revert;
    private void Awake()
    {
        gameObject.SetActive(Application.isEditor ^ _revert);
    }
}
