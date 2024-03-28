using UnityEngine;

public class CompositeRootMenuUI : MonoBehaviour
{
    [SerializeField] private InfoSettings _infoSettings;
    [SerializeField] private InfoShopUI _infoShopUI;
    [SerializeField] private InfoLevelsUI _infoLevelsUI;

    private CompositeRootSettingsUI _settingsUI;
    private CompositeRootShopUI _shopUI;
    private CompositeRootLevelsUI _levelsUI;

    private void Awake()
    {
        _settingsUI = new CompositeRootSettingsUI(_infoSettings);
        _shopUI = new CompositeRootShopUI(_infoShopUI);
        _levelsUI = new CompositeRootLevelsUI(_infoLevelsUI);
    }

    private void Start()
    {
        _shopUI.Start();
        _levelsUI.Start();
    }

    private void OnEnable()
    {
        _settingsUI.Enable();
        _shopUI.Enable();
        _levelsUI.Enable();
    }

    private void OnDisable()
    {
        _settingsUI.Disable();
        _shopUI.Disable();
        _levelsUI.Disable();
    }
}