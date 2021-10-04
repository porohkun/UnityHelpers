using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private float _delta = 1f;
    [SerializeField] private bool _externalFrameCount;

    private float _start;
    private int _frames;

    private void Update()
    {
        var delta = Time.unscaledTime - _start;
        if (delta >= _delta)
        {
            var fps = _frames / delta;
            _text.text = Mathf.RoundToInt(fps).ToString("00");
            _frames = 0;
            _start = Time.unscaledTime;
        }
        else if (!_externalFrameCount)
            RegisterFrame();
    }

    public void RegisterFrame()
    {
        _frames++;
    }
}
