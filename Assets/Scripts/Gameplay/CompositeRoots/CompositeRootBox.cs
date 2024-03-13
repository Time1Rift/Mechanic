using UnityEngine;

public class CompositeRootBox : MonoBehaviour
{
    [SerializeField] private BoxInfo _boxInfo;
    [SerializeField] private BoltSpawner _boltSpawner;

    private BoxView _boxView;
    private Box _box;

    private void Start()
    {
        SpawnPoints spawnPoints = new SpawnPoints();
        _box.Initialize(spawnPoints, _boltSpawner.transform);
    }

    public void Initialize()
    {
        _box = new Box(_boltSpawner, _boxInfo.CountLines);
        _boxView = new BoxView(_boxInfo.OffsetLines);
    }

    public void Enable()
    {
        _boxView.Subscribe(_box);
    }

    public void Disable()
    {
        _boxView.Unsubscribe(_box);
    }
}