using UnityEngine;

public class CompositeRootMenuUI : MonoBehaviour
{
    [SerializeField] private InfoSettings _infoSettings;
    [SerializeField] private InfoShopUI _infoShopUI;
    [SerializeField] private InfoLevelsUI _infoLevelsUI;
    [SerializeField] private InfoLeaderboard _infoLeaderboard;

    private CompositeRootSettingsUI _settingsUI;
    private CompositeRootShopUI _shopUI;
    private CompositeRootLevelsUI _levelsUI;
    private CompositeRootLeaderboard _leaderboard;

    private void Awake()
    {
        _settingsUI = new CompositeRootSettingsUI(_infoSettings);
        _shopUI = new CompositeRootShopUI(_infoShopUI);
        _levelsUI = new CompositeRootLevelsUI(_infoLevelsUI);
        _leaderboard = new CompositeRootLeaderboard(_infoLeaderboard);
    }

    private void Start()
    {
        _settingsUI.Start();
        _shopUI.Start();
        _levelsUI.Start();
    }

    private void OnEnable()
    {
        _settingsUI.Enable();
        _shopUI.Enable();
        _levelsUI.Enable();
        _leaderboard.Enable();
    }

    private void OnDisable()
    {
        _settingsUI.Disable();
        _shopUI.Disable();
        _levelsUI.Disable();
        _leaderboard.Disable();
    }
}