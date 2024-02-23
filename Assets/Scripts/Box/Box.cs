using System;
using System.Collections.Generic;
using UnityEngine;

public class Box
{
    private int _countLines = 6;
    private BoltSpawner _spawner;
    private Dictionary<Vector3, List<Bolt>> _bolts = new();

    public Box(BoltSpawner boltSpawner, int countLines)
    {
        if (boltSpawner == null)
            throw new InvalidOperationException(nameof(boltSpawner));

        _spawner = boltSpawner;
        _countLines = countLines;
    }

    public event Action<KeyValuePair<Vector3, List<Bolt>>> ListBoltsCreated;

    public void Initialize(SpawnPoints spawnPoints)
    {
        Vector3[] _points = spawnPoints.GetPoints();

        foreach (var item in _points)
            _bolts.Add(item, new List<Bolt>());

        CreatBolts();
    }

    private void CreatBolts()
    {
        foreach (var item in _bolts)
        {
            List<Bolt> bolts = item.Value;

            while (bolts.Count < _countLines)
            {
                Bolt bolt = _spawner.GetBolt(item.Key);
                bolt.Pressed += OnPressed;
                bolts.Insert(0, bolt);
            }

            ListBoltsCreated?.Invoke(item);   //  BoxView
        }

        ActivateBoltInteractions();
    }

    private void OnPressed(Bolt bolt)
    {
        bolt.Pressed -= OnPressed;

        if (_bolts.ContainsKey(bolt.Parent))
        {
            List<Bolt> bolts = _bolts[bolt.Parent];
            bolts.RemoveAt(bolts.Count - 1);

            CreatBolts();
        }
    }

    private void ActivateBoltInteractions()
    {
        foreach (var item in _bolts)
        {
            List<Bolt> bolts = item.Value;
            bolts[bolts.Count - 1].Enable();
        }
    }
}