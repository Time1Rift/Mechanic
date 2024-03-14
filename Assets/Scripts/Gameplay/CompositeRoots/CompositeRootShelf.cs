using UnityEngine;

public class CompositeRootShelf : MonoBehaviour
{
    [SerializeField] private ShelfInfo _shelfInfo;
    [SerializeField] private ShelfViewInfo _shelfViewInfo;
    [SerializeField] private BoltSpawner _spawner;
    [SerializeField] private Transform _shelTransform;
    [SerializeField] private CompositeRootGameplayUI _buttonReboot;
    [SerializeField] private CompositeRootConstruction _figured;

    private ShelfView _shelfView;
    private ShelfConnector _shelfConnector;
    private ShelfInspector _shelfInspector;
    private Shelf _shelf;

    public void Initialize()
    {
        _shelf = new Shelf(_spawner, _shelfInfo.MaxBolts);
        _shelfView = new ShelfView(_shelfViewInfo, _shelTransform, _shelf);
        _shelfInspector = new ShelfInspector(_shelfInfo.CountBoltsAddition, _shelfInfo.MaxBolts, _spawner.CountVarietyBolt);
        _shelfConnector = new ShelfConnector(_shelfInspector, _shelf, _shelfView);
    }

    public void Enable()
    {
        _spawner.BoltCreated += OnBoltCreated;
        _spawner.Unsubscribed += OnUnsubscribe;
        _figured.SubscribeFigured().ItemReceived += OnItemReceived;
        _shelfConnector.Enable();

        foreach (var reboot in _buttonReboot.GetButtonReboots())
            reboot.ShelfCleared += ClearShelf;
    }    

    public void Disable()
    {
        _spawner.BoltCreated -= OnBoltCreated;
        _spawner.Unsubscribed -= OnUnsubscribe;
        _figured.SubscribeFigured().ItemReceived -= OnItemReceived;
        _shelfConnector.Disable();

        foreach (var reboot in _buttonReboot.GetButtonReboots())
            reboot.ShelfCleared += ClearShelf;
    }

    public ILosed GetILosed() => _shelfConnector;

    private void ClearShelf()
    {
        _shelf.ClearShelf();
        _shelfView.ClearShelf();
    }

    private void OnBoltCreated(Bolt bolt) => _shelfConnector.SubscribeBoli(bolt);   
    
    private void OnUnsubscribe(Bolt bolt) => _shelfConnector.UnsubscribeBolt(bolt);

    private void OnItemReceived() => _shelfConnector.TryRemove();
}