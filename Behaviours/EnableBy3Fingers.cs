using UnityEngine;

public class EnableBy3Fingers : MonoBehaviour
{
    [SerializeField] private float _touchDuration = 3f;
    [SerializeField] private GameObject[] _objects;

    private bool _touching;
    private float _touchBegin;

    private void Update()
    {
        if (Input.touchCount == 3)
            if (!_touching)
            {
                _touching = true;
                _touchBegin = Time.realtimeSinceStartup;
            }
            else if (Time.realtimeSinceStartup - _touchBegin >= _touchDuration)
                foreach (var obj in _objects)
                    obj.SetActive(true);
            else { }
        else
            _touching = false;
    }
}

