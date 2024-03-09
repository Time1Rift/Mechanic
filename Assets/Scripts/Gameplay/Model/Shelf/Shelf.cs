using System.Collections.Generic;
using UnityEngine;

public class Shelf
{
    private List<Bolt> _bolts = new();
    private Transform _transform;
    private BoltSpawner _spawner;

    public Shelf(Transform transform, BoltSpawner spawner)
    {
        _transform = transform;
        _spawner = spawner;
    }

    public int CountBolts => _bolts.Count;
    public IReadOnlyList<Bolt> Bolts => _bolts;

    public void Remove(Bolt bolt) => _bolts.Remove(bolt);

    public void DisableBolt(Bolt bolt) => _spawner.SetObgect(bolt);

    public void ClearShelf()
    {
        if (CountBolts == 0)
            return;

        for (int i = 0; i < _bolts.Count; i++)
            DisableBolt(_bolts[i]);

        _bolts.Clear();
    }

    public void AddBolt(Bolt bolt)
    {
        _bolts.Add(bolt);
        bolt.transform.SetParent(_transform);
    }

    public Bolt GetBolt(int number) => _spawner.GetBolt(number);
}