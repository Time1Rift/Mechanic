using System;
using System.Collections.Generic;
using UnityEngine;

public class Shelf
{
    private List<Bolt> _bolts = new();
    private Transform _transform;
    private ShelfConnector _shelfConnector;
    private int _maxBolts;

    public Shelf(Transform transform, ShelfConnector shelfConnector, int maxBolts)
    {
        _transform = transform;
        _shelfConnector = shelfConnector;
        _maxBolts = maxBolts;
    }

    public event Action<Transform, int> BoltsDrawed;
    public event Action Losed;

    public void Subscribe(Bolt bolt) => bolt.Pressed += OnPressed;

    private void OnPressed(Bolt bolt)
    {
        bolt.Pressed -= OnPressed;

        _bolts.Add(bolt);
        Transform transformBolt = bolt.transform;
        transformBolt.SetParent(_transform);
        BoltsDrawed?.Invoke(transformBolt, _bolts.Count);

        _shelfConnector.TryRemove(bolt, _bolts);
        _shelfConnector.FoldBolts(_bolts, _transform);

        if (_bolts.Count == _maxBolts)
        {
            Losed?.Invoke();
            Debug.Log("Los");
        }
    }
}