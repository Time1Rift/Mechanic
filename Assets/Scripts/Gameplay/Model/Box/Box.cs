using System;
using System.Collections.Generic;
using UnityEngine;

public class Box : IBoltsDrawed
{
    private List<BoltColumn> _boltColumns = new();
    private int _countLines = 6;
    private BoltSpawner _spawner;

    public Box(BoltSpawner boltSpawner, int countLines)
    {
        _spawner = boltSpawner;
        _countLines = countLines;
    }

    public event Action<BoltColumn> BoltsDrawed;

    public void Initialize(SpawnPoints spawnPoints, Transform transform)
    {
        Transform[] _points = spawnPoints.GetPoints(transform);

        foreach (var point in _points)
            _boltColumns.Add(new BoltColumn(point));

        CreatBolts();
    }

    private void ActivateClick()
    {
        foreach (var item in _boltColumns)
            item.ActivateClick();
    }

    private void CreatBolts()
    {
        Bolt bolt;

        foreach (var item in _boltColumns)
        {
            while (item.Count < _countLines)
            {
                bolt = _spawner.GetBolt();
                bolt.Pressed += OnPressed;
                item.AddBolt(bolt);
            }

            BoltsDrawed?.Invoke(item);   //  BoxView
        }

        ActivateClick();
    }

    private void OnPressed(Bolt bolt)
    {
        bolt.Pressed -= OnPressed;

        foreach (var item in _boltColumns)
        {
            if (item.TryDeleteBolt(bolt))
            {
                CreatBolts();
                return;
            }
        }
    }
}