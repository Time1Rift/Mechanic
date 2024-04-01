using UnityEngine;

public class ItemOnScreenPosition : MonoBehaviour
{
    [SerializeField] private Vector3 _portraitPosition;
    [SerializeField] private Vector3 _landscapePosition;

    private Transform _transform;
    private bool _isWorking;

    private void Awake()
    {
        _transform = transform;
    }

    private void FixedUpdate()
    {
        _isWorking = Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown;
        _transform.localPosition = _isWorking ? _portraitPosition : _landscapePosition;
    }
}