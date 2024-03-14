using UnityEngine;

public class CompositeRootConstruction : MonoBehaviour
{
    [SerializeField] private ConstructionViewInfo _constructionViewInfo;
    [SerializeField] private Constructions _prefabs;
    [SerializeField] private BoltSpawner _boltSpawner;
    [SerializeField] private Transform _Construction;

    private ConstructionView _view;
    private Construction _construction;

    private void Start()
    {
        _construction.SetDetail();
    }

    public void Initialize()
    {
        ConstructionPrefab prefab = GetPrefab();
        _view = new ConstructionView(prefab.Preview, prefab.NumberText, _constructionViewInfo);
        _construction = new Construction(prefab.Model, _view);
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

    private ConstructionPrefab GetPrefab()
    {
        if (PlayerPrefs.HasKey("CountConstructions") == false)
            PlayerPrefs.SetInt("CountConstructions", _prefabs.Count);

        return Instantiate(_prefabs.CountConstruction[Random.Range(0, PlayerPrefs.GetInt("CountConstructions"))], _Construction);
    }
}