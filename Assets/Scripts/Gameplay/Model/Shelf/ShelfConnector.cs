using System;
using System.Linq;

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

    public void Subscribe(Bolt bolt) => bolt.Pressed += OnPressed;

    public void Unsubscribe(Bolt bolt) => bolt.Pressed -= OnPressed;

    private void OnPressed(Bolt bolt)
    {
        bolt.Pressed -= OnPressed;
        _shelfView.MoverBolt(bolt);
    }

    private void OnMoved(Bolt bolt)
    {
        TryRemove(bolt);
        FoldBolts();
        TryLosed();
    }

    private void TryRemove(Bolt bolt)
    {
        if (_shelfInspector.TryRemove(bolt))
            _shelfView.RemoveBolt(bolt);
        else
            _shelf.AddBolt(bolt);
    }

    private void FoldBolts()
    {
        if (_shelfInspector.FoldBolts(_shelf.Bolts, out IGrouping<int, Bolt> duplicates))
        {
            _shelfView.ConnectBolts(duplicates);
            _followingNumber = duplicates.Key;

            foreach (var bolt in duplicates)
                _shelf.Remove(bolt);
        }
    }

    private void ConnectBolts()
    {
        _newBolt = _shelf.GetBolt(_followingNumber);
        _shelfView.Pulsate(_newBolt);
    }

    private void OnPulsated(Bolt bolt) 
    {
        TryRemove(bolt);
        FoldBolts();
    }

    private void TryLosed()
    {
        if (_shelfInspector.TryLosed(_shelf.CountBolts))
            Losed?.Invoke();
    }
}