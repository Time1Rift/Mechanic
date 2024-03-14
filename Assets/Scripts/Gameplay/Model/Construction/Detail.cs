using System.Collections.Generic;
using UnityEngine;

public class Detail
{
    private Queue<PartDetail> _points = new();
    private Transform _transformModel;

    public Detail(Transform transform)
    {
        _transformModel = transform.GetChild(0);

        for (int i = 1; i < transform.childCount; i++)
            _points.Enqueue(transform.GetChild(i).GetComponent<PartDetail>());
    }

    public bool TryCount => _points.Count > 0;

    public void Draw() => _transformModel.gameObject.SetActive(true);

    public PartDetail GetPartDetail() => _points.Dequeue();
}