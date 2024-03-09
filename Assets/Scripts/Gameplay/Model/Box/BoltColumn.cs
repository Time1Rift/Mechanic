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

    public void CanTrackClicks(bool isWorking) => _bolts.Peek().CanTrackClicks(isWorking);

    public bool TryDeleteBolt(Bolt bolt)
    {
        bool isDeleted = bolt == _bolts.Peek();

        if (isDeleted)
            _bolts.Dequeue();

        return isDeleted;
    }

    public List<Transform> GetPositionBolts()
    {
        List<Transform> transforms = new();

        foreach (var bolt in _bolts)
            transforms.Add(bolt.transform);

        return transforms;
    }
}