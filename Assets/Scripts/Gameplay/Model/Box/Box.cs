using System;
using System.Collections.Generic;
using UnityEngine;

public class Box : IBoltsDrawed
{
    private List<BoltColumn> _boltColumns = new();
    private int _countLines = 6;
    private BoltSpawner _spawner;
    private bool _isTrackClicks = true;

    public Box(BoltSpawner boltSpawner, int countLines)
    {
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

    public void CanTrackClicks(bool isTrackClicks)
    {
        _isTrackClicks = isTrackClicks;
        CanTrackClicks();
    }

    private void CanTrackClicks()
    {
        foreach (var item in _boltColumns)
            item.CanTrackClicks(_isTrackClicks);
    }

    private void CreatBolts()
    {
        foreach (var item in _boltColumns)
        {
            while (item.Count < _countLines)
            {
                Bolt bolt = _spawner.GetBolt();
                bolt.Pressed += OnPressed;
                item.AddBolt(bolt);
            }

            BoltsDrawed?.Invoke(item);   //  BoxView
        }

        if (_isTrackClicks)
            CanTrackClicks();
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