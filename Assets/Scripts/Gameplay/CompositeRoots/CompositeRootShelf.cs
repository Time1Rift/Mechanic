using UnityEngine;

public class CompositeRootShelf : MonoBehaviour
{
    [SerializeField] private ShelfInfo _shelfInfo;
    [SerializeField] private ShelfViewInfo _shelfViewInfo;
    [SerializeField] private BoltSpawner _spawner;
    [SerializeField] private Transform _shelTransform;
    [SerializeField] private CompositeRootGameplayUI _buttonReboot;

    private ShelfView _shelfView;
    private ShelfConnector _shelfConnector;
    private ShelfInspector _shelfInspector;
    private Shelf _shelf;

    private void Update()
    {
        _shelfView.Update(Time.deltaTime);
    }

    public void Initialize()
    {
        _shelf = new Shelf(_shelTransform, _spawner);
        _shelfView = new ShelfView(_shelfViewInfo, _shelTransform, _shelfInfo.MaxBolts, _shelf);
        _shelfInspector = new ShelfInspector(_shelfInfo.CountBoltsAddition, _shelfInfo.MaxBolts);
        _shelfConnector = new ShelfConnector(_shelfInspector, _shelf, _shelfView);
    }

    public void Enable()
    {
        _spawner.BoltCreated += OnBoltCreated;
        _spawner.Unsubscribed += OnUnsubscribe;
        _shelfConnector.Enable();

        foreach (var reboot in _buttonReboot.GetButtonReboots())
            reboot.ShelfCleared += ClearShelf;
    }    

    public void Disable()
    {
        _spawner.BoltCreated -= OnBoltCreated;
        _spawner.Unsubscribed -= OnUnsubscribe;
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

    private void OnBoltCreated(Bolt bolt) => _shelfConnector.Subscribe(bolt);   
    
    private void OnUnsubscribe(Bolt bolt) => _shelfConnector.Unsubscribe(bolt);    
}