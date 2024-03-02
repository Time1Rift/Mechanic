public class CompositeRootBox
{
    private BoxView _boxView;
    private Box _box;
    private SpawnPoints _spawnPoints;

    public CompositeRootBox(BoxInfo boxInfo, BoltSpawner boltSpawner)
    {
        _spawnPoints = new SpawnPoints(boltSpawner.transform, boxInfo.OffsetColumns);
        _box = new Box(boltSpawner, boxInfo.CountLines);
        _boxView = new BoxView(boxInfo.OffsetLines);
    }

    public void Start()
    {
        _box.Initialize(_spawnPoints);
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