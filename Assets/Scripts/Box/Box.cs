using System;
using System.Collections.Generic;
using UnityEngine;

public class Box
{
    private List<BoltColumn> _boltColumns = new();
    private int _countLines = 6;
    private BoltSpawner _spawner;

    public Box(BoltSpawner boltSpawner, int countLines)
    {
        if (boltSpawner == null)
            throw new InvalidOperationException(nameof(boltSpawner));

        _spawner = boltSpawner;
        _countLines = countLines;
    }

    public event Action<BoltColumn> BoltsDrawed;

    public void Initialize(SpawnPoints spawnPoints)
    {
        Transform[] _points = spawnPoints.GetPoints();

        foreach (var point in _points)
            _boltColumns.Add(new BoltColumn(point));

        CreatBolts();
    }

    private void CreatBolts()
    {
        foreach (var item in _boltColumns)
        {
            while (item.Count < _countLines)
            {
                Bolt bolt = _spawner.GetBolt(item.Position);
                bolt.Pressed += OnPressed;
                item.AddBolt(bolt);
            }

            BoltsDrawed?.Invoke(item);   //  BoxView
        }

        ActivateBoltInteractions();
    }

    private void OnPressed(Bolt bolt)
    {
        bolt.Pressed -= OnPressed;

        foreach (var item in _boltColumns)
        {
            if (item.TryDeleteBolt(bolt))
            {
                item.DeleteBolt();
                CreatBolts();
                return;
            }
        }
    }

    private void ActivateBoltInteractions()
    {
        foreach (var item in _boltColumns)
            item.ActivateBolt();
    }
}