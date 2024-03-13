using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class Parallax : MonoBehaviour
{
    [SerializeField] private float _speed;

    private RawImage _imoge;
    private float _imogePositionX;

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

        _imoge.uvRect = new Rect(_imogePositionX, 0, _imoge.uvRect.width, _imoge.uvRect.height);
    }
}
