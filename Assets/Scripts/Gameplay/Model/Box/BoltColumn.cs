using System.Collections.Generic;
using UnityEngine;

public class BoltColumn
{
    private Transform _transform;
    private Queue<Bolt> _bolts = new();

    public BoltColumn(Transform transform)
    {
        _transform = transform;
    }

    public int Count => _bolts.Count;

    public Vector3 Position => _transform.position;

    public void AddBolt(Bolt bolt) => _bolts.Enqueue(bolt);

    public void ActivateBolt() => _bolts.Peek().Enable();

    public bool TryDeleteBolt(Bolt bolt) => bolt == _bolts.Peek();

    public void DeleteBolt() => _bolts.Dequeue();

    public List<Transform> GetPositionBolts()
    {
        List<Transform> transforms = new();

        foreach (var bolt in _bolts)
            transforms.Add(bolt.transform);

        return transforms;
    }
}