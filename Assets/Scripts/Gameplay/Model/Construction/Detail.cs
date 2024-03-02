using System.Collections.Generic;
using UnityEngine;

public class Detail
{
    private Queue<Transform> _points = new();
    private Transform _transform;

    public Detail(Transform transform)
    {
        _transform = transform;

        for (int i = 0; i < transform.childCount; i++)
            _points.Enqueue(transform.GetChild(i));

        Number = 4;
    }

    public int Number { get; private set; }
    public bool TryCount => _points.Count > 0;

    public void Draw() => _transform.gameObject.SetActive(true);

    public Transform GetPoint() => _points.Dequeue();
}