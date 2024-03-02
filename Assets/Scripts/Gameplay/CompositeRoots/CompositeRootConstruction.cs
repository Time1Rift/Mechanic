public class CompositeRootConstruction
{
    private ConstructionView _view;
    private Construction _construction;

    public CompositeRootConstruction(ConstructionPrefab prefab)
    {
        _view = new ConstructionView(prefab.RectTransform, prefab.NumberText);
        _construction = new Construction(prefab.Model, _view);
    }

    public void Start()
    {
        _construction.SetDetail();
    }

    public void Enable(IBoltCreated boltSpawner)
    {
        boltSpawner.BoltCreated += OnBoltCreated;
    }

    public void Disable(IBoltCreated boltSpawner)
    {
        boltSpawner.BoltCreated -= OnBoltCreated;
    }

    public IWin GetIWin() => _construction;

    private void OnBoltCreated(Bolt bolt) => _construction.Subscribe(bolt);
}