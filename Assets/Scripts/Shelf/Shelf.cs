using System;
using System.Collections.Generic;
using UnityEngine;

public class Shelf
{
    private List<Bolt> _bolts = new();
    private Transform _transform;
    private ShelfSorter _shelfSorter;
    private int _maxBolts;

    public Shelf(Transform transform, ShelfSorter shelfSorter, int maxBolts)
    {
        _transform = transform;
        _shelfSorter = shelfSorter;
        _maxBolts = maxBolts;
    }

    public event Action<Transform, int> BoltsDrawed;
    public event Action Losed;

    public void Subscribe(Bolt bolt) => bolt.Pressed += OnPressed;

    private void OnPressed(Bolt bolt)
    {
        bolt.Pressed -= OnPressed;

        _bolts.Add(bolt);
        bolt.transform.SetParent(_transform);
        BoltsDrawed?.Invoke(bolt.transform, _bolts.Count);

        _shelfSorter.CanNumber(_bolts);
        _shelfSorter.FoldBolts(_bolts, _transform);

        if (_bolts.Count == _maxBolts)
            Losed?.Invoke();
    }
}