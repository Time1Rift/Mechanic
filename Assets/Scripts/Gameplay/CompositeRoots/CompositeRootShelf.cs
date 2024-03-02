using UnityEngine;

public class CompositeRootShelf
{
    private BoltSpawner _spawner;

    private ShelfView _shelfView;
    private Shelf _shelf;
    private ShelfConnector _shelfConnector;

    public CompositeRootShelf(ShelfInfo shelfInfo, Transform transform, BoltSpawner spawner)
    {
        _spawner = spawner;
        _shelfView = new ShelfView(shelfInfo.Offset, transform);
        _shelfConnector = new ShelfConnector(shelfInfo.CountBoltsAddition, _spawner);
        _shelf = new Shelf(transform, _shelfConnector, shelfInfo.MaxBolts);
    }

    public void Enable()
    {
        _shelfView.Subscribe(_shelf);
        _spawner.BoltCreated += OnBoltCreated;
    }

    public void Disable()
    {
        _shelfView.Unsubscribe(_shelf);
        _spawner.BoltCreated -= OnBoltCreated;
    }

    public ILosed GetILosed() => _shelf;

    private void OnBoltCreated(Bolt bolt) => _shelf.Subscribe(bolt);
}