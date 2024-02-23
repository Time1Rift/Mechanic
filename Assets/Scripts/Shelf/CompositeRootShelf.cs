using UnityEngine;

public class CompositeRootShelf : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField, Min(0f)] private float _offset = 1.1f;
    [SerializeField, Min(0)] private int _maxBolts = 5;
    [SerializeField, Min(0)] private int _countBoltsAddition = 3;
    [SerializeField] private BoltSpawner _spawner;
    [SerializeField] private Construction _construction;                //      не забыть это убрать 

    private ShelfView _shelfView;
    private Shelf _shelf;
    private ShelfSorter _shelfSorter;

    private void Awake()
    {
        _shelfView = new ShelfView(_offset, _transform);
        _shelfSorter = new ShelfSorter(_countBoltsAddition, _construction, _spawner);
        _shelf = new Shelf(_transform, _shelfSorter, _maxBolts);
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