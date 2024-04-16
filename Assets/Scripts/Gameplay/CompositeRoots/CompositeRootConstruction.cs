using UnityEngine;

public class CompositeRootConstruction : MonoBehaviour
{
    [SerializeField] private ConstructionViewInfo _constructionViewInfo;
    [SerializeField] private ListLevels _listLevels;
    [SerializeField] private BoltSpawner _boltSpawner;
    [SerializeField] private Transform _positionConstruction;

    private ConstructionView _view;
    private Construction _construction;
    private Figure _figure;

    private void Start()
    {
        _construction.SetDetail();
    }

    public void Initialize()
    {
        ReceiveFigure();
        _view = new ConstructionView(_figure, _constructionViewInfo);
        _construction = new Construction(_figure, _view);
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

    private void ReceiveFigure()
    {
        PlayerDataSelectedLevel Levels = new PlayerDataSelectedLevel();
        int level = Levels.GetValue();

        if (level > _listLevels.CountLevels)
        {
            Levels.ResetLevel();
            level = Levels.GetValue();
        }
        
        Level newLevel = _listLevels.Levels[level - 1];
        _figure = Instantiate(newLevel.Figure, _positionConstruction);
        _figure.Initialized(newLevel.NameFile);
    }
}