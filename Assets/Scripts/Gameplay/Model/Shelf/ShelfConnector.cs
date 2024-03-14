using System;
using System.Linq;
using UnityEngine;

public class ShelfConnector : ILosed
{
    private Shelf _shelf;
    private ShelfInspector _shelfInspector;
    private ShelfView _shelfView;

    private int _followingNumber;
    private Bolt _newBolt;

    public ShelfConnector(ShelfInspector shelfInspector, Shelf shelf, ShelfView shelfView)
    {
        _shelf = shelf;
        _shelfInspector = shelfInspector;
        _shelfView = shelfView;
    }

    public event Action Losed;

    public void Enable()
    {
        _shelfView.Moved += OnMoved;
        _shelfView.Connected += ConnectBolts;
        _shelfView.Pulsated += OnPulsated;
    }

    public void Disable()
    {
        _shelfView.Moved -= OnMoved;
        _shelfView.Connected -= ConnectBolts;
        _shelfView.Pulsated -= OnPulsated;
    }

    public void SubscribeBoli(Bolt bolt) => bolt.Pressed += OnPressed;

    public void UnsubscribeBolt(Bolt bolt) => bolt.Pressed -= OnPressed;

    public void TryRemove()
    {
        if (_shelfInspector.TryRemove(_shelf.Bolts, out Bolt bolt))
        {
            _shelf.Remove(bolt);
            _shelfView.RemoveBolt(bolt);
        }
    }

    private void OnPressed(Bolt bolt)
    {
        if (_shelf.IsShelfFull)
            return;

        UnsubscribeBolt(bolt);
        _shelf.AddBolt(bolt);
        _shelfView.MoverBolt(bolt);
    }

    private void OnMoved()
    {
        TryRemove();
        FoldBolts();
        TryLosed();
    }

    private void FoldBolts()
    {
        if (_shelfInspector.FoldBolts(_shelf.Bolts, out IGrouping<int, Bolt> duplicates))
        {
            foreach (var bolt in duplicates)
                _shelf.Remove(bolt);

            _followingNumber = duplicates.Key;
            _shelfView.ConnectBolts(duplicates);
        }
    }

    private void ConnectBolts()
    {
        _newBolt = _shelf.GetBolt(_followingNumber);

        if(_newBolt != null)
        {
            UnsubscribeBolt(_newBolt);
            _shelf.AddBolt(_newBolt);
            _shelfView.Pulsate(_newBolt);
        }                
    }

    private void OnPulsated()
    {
        TryRemove();
        FoldBolts();
    }

    private void TryLosed()
    {
        if (_shelfInspector.TryLosed(_shelf.CountBolts))
            Losed?.Invoke();
    }
}