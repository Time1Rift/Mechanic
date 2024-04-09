using UnityEngine;

public class CompositeRootShelf : MonoBehaviour
{
    [SerializeField] private ShelfInfo _shelfInfo;
    [SerializeField] private ShelfViewInfo _shelfViewInfo;
    [SerializeField] private BoltSpawner _spawner;
    [SerializeField] private Transform _shelTransform;
    [SerializeField] private AudioSource _effectSoundCub;
    [SerializeField] private AudioSource _folding;
    [SerializeField] private CompositeRootConstruction _construction;
    [SerializeField] private CompositeRootGameplayUI _buttonCleaningShelf;

    private ShelfView _shelfView;
    private ShelfConnector _shelfConnector;
    private ShelfInspector _shelfInspector;
    private Shelf _shelf;

    public void Initialize()
    {
        _shelf = new Shelf(_spawner, _shelfInfo.MaxBolts);
        _shelfView = new ShelfView(_shelfViewInfo, _shelTransform, _shelf, _effectSoundCub, _folding);
        _shelfInspector = new ShelfInspector(_shelfInfo.CountBoltsAddition, _shelfInfo.MaxBolts, _spawner.CountVarietyBolt);
        _shelfConnector = new ShelfConnector(_shelfInspector, _shelf, _shelfView);
    }

    public void Enable()
    {
        _spawner.BoltCreated += OnBoltCreated;
        _spawner.Unsubscribed += OnUnsubscribe;
        _construction.SubscribeFigured().ItemReceived += OnItemReceived;
        _shelfConnector.Enable();

        foreach (var item in _buttonCleaningShelf.ClearShelf())
            item.ShelfCleared += OnClearShelf;
    }    

    public void Disable()
    {
        _spawner.BoltCreated -= OnBoltCreated;
        _spawner.Unsubscribed -= OnUnsubscribe;
        _construction.SubscribeFigured().ItemReceived -= OnItemReceived;
        _shelfConnector.Disable();

        foreach (var item in _buttonCleaningShelf.ClearShelf())
            item.ShelfCleared -= OnClearShelf;
    }

    public ILosed GetILosed() => _shelfConnector;

    private void OnClearShelf()
    {
        _shelf.ClearShelf();
        _shelfView.ClearShelf();
    }

    private void OnBoltCreated(Bolt bolt) => _shelfConnector.SubscribeBoli(bolt);   
    
    private void OnUnsubscribe(Bolt bolt) => _shelfConnector.UnsubscribeBolt(bolt);

    private void OnItemReceived() => _shelfConnector.TryRemove();
}