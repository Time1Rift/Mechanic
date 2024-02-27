using UnityEngine;

public class CompositeRootShelf : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField, Min(0f)] private float _offset = 1.1f;
    [SerializeField, Min(0)] private int _maxBolts = 5;
    [SerializeField, Min(0)] private int _countBoltsAddition = 3;
    [SerializeField] private BoltSpawner _spawner;

    private ShelfView _shelfView;
    private Shelf _shelf;
    private ShelfConnector _shelfConnector;

    private void Awake()
    {
        _shelfView = new ShelfView(_offset, _transform);
        _shelfConnector = new ShelfConnector(_countBoltsAddition, _spawner);
        _shelf = new Shelf(_transform, _shelfConnector, _maxBolts);
    }

    private void OnEnable()
    {
        _shelfView.Subscribe(_shelf);
        _spawner.BoltCreated += OnBoltCreated;
    }

    private void OnDisable()
    {
        _shelfView.Unsubscribe(_shelf);
        _spawner.BoltCreated -= OnBoltCreated;
    }

    private void OnBoltCreated(Bolt bolt) => _shelf.Subscribe(bolt);
}