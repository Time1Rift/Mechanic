using UnityEngine;

public class CompositeRootBox : MonoBehaviour
{
    [SerializeField, Min(0f)] private readonly float _offsetLines = 1f;

    [SerializeField, Min(0)] private int _countLines = 6;
    [SerializeField] private BoltSpawner _boltSpawner;

    [SerializeField, Min(0)] private float _offsetColumns = 1.1f;
    [SerializeField] private Transform _spawnPath;

    private BoxView _boxView;
    private Box _box;
    private SpawnPoints _spawnPoints;

    private void Awake()
    {
        _spawnPoints = new SpawnPoints(_spawnPath, _offsetColumns);
        _box = new Box(_boltSpawner, _countLines);
        _boxView = new BoxView(_offsetLines);
    }

    private void Start()
    {
        _box.Initialize(_spawnPoints);
    }

    private void OnEnable()
    {
        _boxView.Subscribe(_box);
    }

    private void OnDisable()
    {
        _boxView.Unsubscribe(_box);
    }
}