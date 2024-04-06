using UnityEngine;

public class CompositeRootConstruction : MonoBehaviour
{
    [SerializeField] private ConstructionViewInfo _constructionViewInfo;
    [SerializeField] private ListLevels _listLevels;
    [SerializeField] private BoltSpawner _boltSpawner;
    [SerializeField] private Transform _positionConstruction;

    private ConstructionView _view;
    private Construction _construction;

    private void Start()
    {
        _construction.SetDetail();
    }

    public void Initialize()
    {
        Figure prefab = GetPrefab();
        _view = new ConstructionView(prefab.Preview, prefab.NumberText, _constructionViewInfo);
        _construction = new Construction(prefab, _view);
    }

    public void Enable()
    {
        _boltSpawner.BoltCreated += OnBoltCreated;
        _boltSpawner.Unsubscribed += OnUnsubscribe;
    }

    public void Disable()
    {
        _boltSpawner.BoltCreated -= OnBoltCreated;
        _boltSpawner.Unsubscribed -= OnUnsubscribe;
    }

    public IWin GetIWin() => _construction;

    public void ShowEntireStructure(bool isWorking) => _view.ShowEntireStructure(isWorking);

    public IFigured SubscribeFigured() => _construction;

    private void OnBoltCreated(Bolt bolt) => _construction.Subscribe(bolt);

    private void OnUnsubscribe(Bolt bolt) => _construction.Unsubscribe(bolt);

    private Figure GetPrefab()
    {
        PlayerDataSelectedLevel Levels = new PlayerDataSelectedLevel();
        int level = Levels.GetValue();

        if(level > _listLevels.CountLevels)
        {
            Levels.ResetLevel();
            level = Levels.GetValue();
        }

        return Instantiate(_listLevels.GetConstruction(level), _positionConstruction);
    }
}