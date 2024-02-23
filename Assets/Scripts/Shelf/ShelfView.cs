using UnityEngine;

public class ShelfView
{
    private float _offset;
    private Vector3 _offsetBolt;
    private Transform _transform;

    public ShelfView(float offset, Transform transform)
    {
        _offset = offset;
        _transform = transform;
    }

    public void Subscribe(Shelf shelf) => shelf.BoltsDrawed += OnBoltsCreated;

    public void Unsubscribe(Shelf shelf) => shelf.BoltsDrawed -= OnBoltsCreated;

    private void OnBoltsCreated(Transform transform, int number)
    {
        _offsetBolt.x = _offset * number;
        transform.position = _transform.position + _offsetBolt;
    }
}