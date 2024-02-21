using System;
using System.Collections.Generic;
using UnityEngine;

public class BoltsDescent : MonoBehaviour
{
    [SerializeField, Min(0)] private int _countLines = 6;

    private BoltSpawner _spawner;
    private SpawnPoints _spawnPoints;
    private Dictionary<Vector3, List<Bolt>> _bolts = new();

    private Vector3[] _points;

    public event Action<KeyValuePair<Vector3, List<Bolt>>> BoltsCreated;

    private void Awake()
    {
        _spawner = GetComponentInChildren<BoltSpawner>();
        _spawnPoints = GetComponentInChildren<SpawnPoints>();

        if (_spawner == null || _spawnPoints == null)
            throw new InvalidOperationException("_spawner _spawnPoints");
    }

    private void Start()
    {
        _points = _spawnPoints.GetPoints();

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

            BoltsCreated?.Invoke(item);   //  BoxView
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