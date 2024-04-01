using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class Parallax : MonoBehaviour
{
    [SerializeField, Min(0f)] private float _speed;
    [SerializeField, Min(0f)] private float _width = 0.2f;

    private RawImage _imoge;
    private float _imogePositionX;
    private float _currentWidht;
    private bool _isWorking;

    private void Start()
    {
        _imoge = GetComponent<RawImage>();
        _imogePositionX = _imoge.uvRect.x;
    }

    private void Update()
    {
        _imogePositionX += Time.deltaTime * _speed;

        if (_imogePositionX > 1)
            _imogePositionX = 0;

        _isWorking = Screen.orientation == ScreenOrientation.Portrait || Screen.orientation ==  ScreenOrientation.PortraitUpsideDown;
        _currentWidht = _isWorking ? _width : 1;
        _imoge.uvRect = new Rect(_imogePositionX, 0, _currentWidht, _imoge.uvRect.height);
    }
}
