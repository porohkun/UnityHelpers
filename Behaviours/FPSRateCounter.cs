//using UnityEngine;
//using UnityEngine.UI;

//public class FPSRateCounter : MonoBehaviour
//{
//    [SerializeField] private Text _averageFps;
//    [SerializeField] private Text _medianeFps;
//    [SerializeField] private Text _stabilityFps;
//    [SerializeField] private float _delta = 1f;
//    [SerializeField] private bool _externalFrameCount;

//    private float _start;
//    private int _frames;
//    private int[] _framerate;
//    private int _registersCount;
//    private int _summ;

//    private void OnEnable()
//    {
//        _start = Time.unscaledTime;
//        _frames = 0;
//        _registersCount = 0;
//        _summ = 0;
//        _framerate = new int[100];
//    }

//    private void Update()
//    {
//        var delta = Time.unscaledTime - _start;
//        if (delta >= _delta)
//        {
//            var fps = Mathf.RoundToInt(_frames / delta);
//            _framerate[fps]++;
//            _registersCount++;
//            _summ += fps;

//            _averageFps.text = (((float)_summ) / _registersCount).ToString("00");

//            var summ = _registersCount / 2;
//            for (int i = 0; i < _framerate.Length; i++)
//            {
//                summ -= _framerate[i];
//                if (summ <= 0)
//                {
//                    fps = i;
//                    break;
//                }
//            }

//            _medianeFps.text = fps.ToString("00");
//            var value = (float)_framerate[fps];
//            value += (_framerate[fps - 1] + _framerate[fps + 1]) / 2f;
//            value += (_framerate[fps - 2] + _framerate[fps + 2]) / 4f;
//            value += (_framerate[fps - 4] + _framerate[fps + 4]) / 8f;
//            _stabilityFps.text = $"{value / _registersCount * 100}%";

//            _frames = 0;
//            _start = Time.unscaledTime;
//        }
//        else if (!_externalFrameCount)
//            RegisterFrame();
//    }

//    public void RegisterFrame()
//    {
//        _frames++;
//    }

//    public void RegisterFramerate(int framerate)
//    {
//        _framerate[framerate]++;
//    }
//}
